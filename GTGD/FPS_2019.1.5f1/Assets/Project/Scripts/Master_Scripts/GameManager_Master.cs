using UnityEngine;

namespace FPS.Master {
    public class GameManager_Master : MonoBehaviour {
        public event GameEventHandler ToggleMenuUIEvent;
        public event GameEventHandler ToggleInventoryUIEvent;
        public event GameEventHandler RestartLevelEvent;
        public event GameEventHandler GoToMenuSceneEvent;
        public event GameEventHandler GameOverEvent;

        public event GameEventHandler<KeyCode> InputKeyUpEvent;

        public bool IsGameOver;
        public bool IsMenuUIOn;
        public bool IsInventoryUIOn;
        
        public void CallToggleMenuUIEvent() {
            ToggleMenuUIEvent?.Invoke();
        }

        public void CallToggleInventoryUIEvent() {
            ToggleInventoryUIEvent?.Invoke();
        }

        public void CallRestartLevelEvent() {
            RestartLevelEvent?.Invoke();
        }

        public void CallGoToMenuSceneEvent() {
            GoToMenuSceneEvent?.Invoke();
        }

        public void CallGameOverEvent() {
            IsGameOver = true;
            GameOverEvent?.Invoke();
        }

        private void Update() {
            if (Input.GetKeyUp(KeyCode.M))
                InputKeyUpEvent?.Invoke(KeyCode.M);

            if (Input.GetKeyUp(KeyCode.I))
                InputKeyUpEvent?.Invoke(KeyCode.I);

            if (Input.GetKeyUp(KeyCode.Q))
                CallGameOverEvent();
        }
    }
}
