using UnityEngine;

namespace FPS.Master {
    public class GameManager_TogglePause : Subscriber_Base<GameManager_Master> {
        private bool _isPaused;

        private void OnEnable() {
            Master.ToggleInventoryUIEvent += TogglePause;
            Master.ToggleMenuUIEvent += TogglePause;
            Master.RestartLevelEvent += TogglePause;
            Master.GoToMenuSceneEvent += TogglePause;
        }

        private void OnDisable() {
            Master.ToggleInventoryUIEvent -= TogglePause;
            Master.ToggleMenuUIEvent -= TogglePause;
            Master.RestartLevelEvent -= TogglePause;
            Master.GoToMenuSceneEvent -= TogglePause;
        }

        private void TogglePause() {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
        }
    }
}