using UnityEngine;

namespace FPS.Item {
    public class Item_Pickup : Subscriber_Base<Item_Master> { 

        private void OnEnable() {
            Master.PickupEvent += OnPickup;
        }

        private void OnDisable() {
            Master.PickupEvent -= OnPickup;
        }

        private void OnPickup(Transform parent) {
            transform.SetParent(parent);
            Master.CallPickupObjectEvent();
            transform.gameObject.SetActive(false);
        }
    }
}