using UnityEngine;

namespace FPS.Master {
    public class GameManager_ToggleInventoryUI : GameManager_Base {
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

        private void ToggleInventoryUI() {
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