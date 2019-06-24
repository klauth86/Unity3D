using UnityEngine;

namespace FPS.Item {
    [RequireComponent(typeof(Animator))]
    public class Item_ItemUI : Subscriber_Base<Item_Master> {
        [SerializeField] private GameObject _itemUI;

        private void OnEnable() {
            Master.ThrowObjectEvent += DisableUI;
            Master.PickupObjectEvent += EnableUI;
        }

        private void OnDisable() {
            Master.ThrowObjectEvent -= DisableUI;
            Master.PickupObjectEvent -= EnableUI;
        }

        private void EnableUI() {
            if (_itemUI)
                _itemUI.SetActive(true);
        }

        private void DisableUI() {
            if (_itemUI)
                _itemUI.SetActive(false);
        }
    }
}