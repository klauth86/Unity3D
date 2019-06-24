using FPS.GameManager;
using UnityEngine;

namespace FPS.Item {
    public class Item_Rigidbodies : Subscriber_Base<Item_Master> {

        [SerializeField]private Rigidbody[] _rigidbodies;

        private void OnEnable() {
            CheckIfIsInInventory();
            Master.ThrowObjectEvent += SetIsKinematicToFalse;
            Master.PickupObjectEvent += SetIsKinematicToTrue;
        }

        private void CheckIfIsInInventory() {
            if (transform.root.CompareTag(GameManager_References.PlayerTag))
                SetIsKinematicToTrue();
        }

        private void OnDisable() {
            Master.ThrowObjectEvent -= SetIsKinematicToFalse;
            Master.PickupObjectEvent -= SetIsKinematicToTrue;
        }

        private void SetIsKinematicToFalse() {
            if (_rigidbodies != null)
                foreach (var rb in _rigidbodies) {
                    rb.isKinematic = false;

                }
        }

        private void SetIsKinematicToTrue() {
            if (_rigidbodies != null)
                foreach (var rb in _rigidbodies) {
                    rb.isKinematic = true;
                    
                }
        }
    }
}