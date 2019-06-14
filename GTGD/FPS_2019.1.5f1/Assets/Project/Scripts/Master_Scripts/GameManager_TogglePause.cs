using UnityEngine;

namespace FPS.Master {
    public class GameManager_TogglePause : GameManager_Base {
        private bool _isPaused;

        private void OnEnable() {
            Master.ToggleInventoryUIEvent += TogglePause;
            Master.ToggleMenuUIEvent += TogglePause;
        }

        private void OnDisable() {
            Master.ToggleInventoryUIEvent -= TogglePause;
            Master.ToggleMenuUIEvent -= TogglePause;
        }

        private void TogglePause() {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
        }
    }
}