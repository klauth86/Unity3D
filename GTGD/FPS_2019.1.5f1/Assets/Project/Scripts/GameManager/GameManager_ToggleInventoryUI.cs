using UnityEngine;

namespace FPS.GameManager {
    public class GameManager_ToggleInventoryUI : Subscriber_Base<GameManager_Master> {
        [SerializeField]private GameObject _inventoryUI;

        private void OnEnable() {
            Master.InputKeyUpEvent += KeyToggleMenuUI;
        }

        private void OnDisable() {
            Master.InputKeyUpEvent -= KeyToggleMenuUI;
        }

        private void KeyToggleMenuUI(KeyCode key) {
            if (key == KeyCode.I && !Master.IsMenuUIOn && !Master.IsGameOver)
                ToggleInventoryUI();

        }

        public void ToggleInventoryUI() {
            if (_inventoryUI) {
                _inventoryUI.SetActive(!_inventoryUI.activeSelf);
            }
            else {
                Debug.LogWarning("InventoryUI is not set!");
            }
            Master.IsInventoryUIOn = !Master.IsInventoryUIOn;
            Master.CallToggleInventoryUIEvent();
        }
    }
}