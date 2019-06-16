using UnityEngine;

namespace FPS.Master {
    public class GameManager_ToggleInstructionsUI : GameManager_Base {
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