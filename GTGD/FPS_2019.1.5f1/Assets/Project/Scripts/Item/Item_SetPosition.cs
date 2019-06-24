using FPS.GameManager;
using UnityEngine;

namespace FPS.Item {
    public class Item_SetPosition : Subscriber_Base<Item_Master> {
        [SerializeField] private Vector3 _localPos;

        private void OnEnable() {
            CheckIfIsInInventory();
            Master.PickupObjectEvent += SetLocalPosition;
        }

        private void CheckIfIsInInventory() {
            if (transform.root.CompareTag(GameManager_References.PlayerTag))
                SetLocalPosition();
        }

        private void OnDisable() {
            Master.PickupObjectEvent -= SetLocalPosition;
        }

        private void SetLocalPosition() {
            transform.localPosition = _localPos;
        }
    }
}