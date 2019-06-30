using UnityEngine;

namespace FPS.Enemy {
    public class Enemy_Ragdoll : RootSubscriber_Base<Enemy_Master> {

        private void OnEnable() {
            Master.DieEvent += ActivateRagdoll;
        }

        private void OnDisable() {
            Master.DieEvent -= ActivateRagdoll;
        }

        private void ActivateRagdoll() {
            var collider = GetComponent<Collider>();
            if (collider) {
                collider.isTrigger = false;
                collider.enabled = true;
            }

            var rb = GetComponent<Rigidbody>();
            if (rb) {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }
    }
}