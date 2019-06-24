using FPS.GameManager;
using UnityEngine;

namespace FPS.Item {
    public class Item_Layer : Subscriber_Base<Item_Master> {
        [SerializeField] private string _throwLayer;
        [SerializeField] private string _pickupLayer;

        private void OnEnable() {
            CheckIfIsInInventory();
            Master.ThrowObjectEvent += SetThrowLayer;
            Master.PickupObjectEvent += SetPickupLayer;
        }

        private void CheckIfIsInInventory() {
            if (transform.root.CompareTag(GameManager_References.PlayerTag))
                SetPickupLayer();
            else
                SetThrowLayer();
        }

        private void OnDisable() {
            Master.ThrowObjectEvent -= SetThrowLayer;
            Master.PickupObjectEvent -= SetPickupLayer;
        }

        private void SetPickupLayer() {
            SetLayer(transform, _pickupLayer);
        }

        private void SetThrowLayer() {
            SetLayer(transform, _throwLayer);
        }

        private void SetLayer(Transform tform, string layer) {
            tform.gameObject.layer = LayerMask.NameToLayer(layer);
            foreach (Transform item in tform) {
                SetLayer(item, layer);
            }
        }
    }
}