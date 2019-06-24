using FPS.GameManager;
using UnityEngine;

namespace FPS.Item {
    public class Item_Colliders : Subscriber_Base<Item_Master> {
        [SerializeField] private Collider[] _colliders;
        [SerializeField] private PhysicMaterial _physMaterial;

        private void OnEnable() {
            CheckIfIsInInventory();
            Master.ThrowObjectEvent += EnableColliders;
            Master.PickupObjectEvent += DisableColliders;
        }

        private void CheckIfIsInInventory() {
            if (transform.root.CompareTag(GameManager_References.PlayerTag))
                DisableColliders();
        }

        private void OnDisable() {
            Master.ThrowObjectEvent -= EnableColliders;
            Master.PickupObjectEvent -= DisableColliders;
        }

        private void DisableColliders() {
            if (_colliders != null)
                foreach (var cl in _colliders) {
                    cl.enabled = false;
                }
        }

        private void EnableColliders() {
            if (_colliders != null)
                foreach (var cl in _colliders) {
                    cl.enabled = true;
                    if (_physMaterial != null)
                        cl.material = _physMaterial;
                }
        }
    }
}