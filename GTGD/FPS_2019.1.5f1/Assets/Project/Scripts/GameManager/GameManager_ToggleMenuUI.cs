using UnityEngine;

namespace FPS.GameManager {
    public class GameManager_ToggleMenuUI : Subscriber_Base<GameManager_Master> {
        [SerializeField]private GameObject _menuUI;

        private void OnEnable() {
            Master.GameOverEvent += ToggleMenuUI;
            Master.InputKeyUpEvent += KeyToggleMenuUI;
        }

        private void OnDisable() {
            Master.GameOverEvent -= ToggleMenuUI;
            Master.InputKeyUpEvent -= KeyToggleMenuUI;
        }

        private void KeyToggleMenuUI(KeyCode key) {
            if (key == KeyCode.M && !Master.IsInventoryUIOn && !Master.IsGameOver)
                ToggleMenuUI();

        }

        private void ToggleMenuUI() {
            if (_menuUI) {
                _menuUI.SetActive(!_menuUI.activeSelf);
            }
            else {
                Debug.LogWarning("MenuUI is not set!");
            }
            Master.IsMenuUIOn = !Master.IsMenuUIOn;
            Master.CallToggleMenuUIEvent();
        }
    }
}