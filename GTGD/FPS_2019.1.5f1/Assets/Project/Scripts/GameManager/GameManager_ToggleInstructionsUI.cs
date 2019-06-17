using UnityEngine;

namespace FPS.GameManager {
    public class GameManager_ToggleInstructionsUI : Subscriber_Base<GameManager_Master> {
        [SerializeField]private GameObject _instructionsUI;

        private void OnEnable() {
            Master.GameOverEvent += ToggleInstructionsUIOff;
        }

        private void OnDisable() {
            Master.GameOverEvent -= ToggleInstructionsUIOff;
        }

        private void ToggleInstructionsUIOff() {
            if (_instructionsUI) {
                _instructionsUI.SetActive(false);
            }
            else {
                Debug.LogWarning("InstructionsUI is not set!");
            }
        }
    }
}