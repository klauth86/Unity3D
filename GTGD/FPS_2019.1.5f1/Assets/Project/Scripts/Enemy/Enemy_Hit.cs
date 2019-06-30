using UnityEngine;

namespace FPS.Enemy {
    [RequireComponent(typeof(Collider))]
    public class Enemy_Hit : RootSubscriber_Base<Enemy_Master> {

        [SerializeField] private float _multiplier = 0.1f;
        [SerializeField] private float _massRequirement = 50;
        [SerializeField] private float _velocityRequirement = 5;

        private void OnEnable() {
            Master.DieEvent += RemoveThis;
        }

        private void OnDisable() {
            Master.DieEvent -= RemoveThis;
        }

        private void RemoveThis() {
            Destroy(gameObject);
        }
        private void OnTriggerEnter(Collider other) {
            var rb = other.GetComponent<Rigidbody>();
            if (rb && rb.mass > _massRequirement && rb.velocity.sqrMagnitude > _velocityRequirement * _velocityRequirement) {
                Master.CallDecreaseHealthEvent(Mathf.CeilToInt(rb.velocity.magnitude * rb.mass * _multiplier));
            }
        }
    }
}