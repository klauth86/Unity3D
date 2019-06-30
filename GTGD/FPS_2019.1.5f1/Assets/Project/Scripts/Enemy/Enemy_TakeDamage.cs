using UnityEngine;

namespace FPS.Enemy {
    public class Enemy_TakeDamage : RootSubscriber_Base<Enemy_Master> {

        [SerializeField] private int _multiplier = 1;
        [SerializeField] private bool _removeCollider = false;

        private void OnEnable() {
            Master.DieEvent += RemoveThis;
        }

        private void OnDisable() {
            Master.DieEvent -= RemoveThis;
        }

        private void RemoveThis() {
            if (_removeCollider) {
                var collider = GetComponent<Collider>();
                if (collider)
                    Destroy(collider);

                var rb = GetComponent<Rigidbody>();
                if (rb)
                    Destroy(rb);
            }
            Destroy(this);
        }

        private void TakeDamage(int amount) {
            Master.CallDecreaseHealthEvent(amount * _multiplier);
        }
    }
}