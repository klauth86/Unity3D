using UnityEngine;

namespace FPS.Master {
    public class GameManager_ToggleCursor : GameManager_Base {
        private bool _isCursorLocked = true;

        private void OnEnable() {
            Master.ToggleInventoryUIEvent += ToggleCursorLocked;
            Master.ToggleMenuUIEvent += ToggleCursorLocked;
        }

        private void OnDisable() {
            Master.ToggleInventoryUIEvent -= ToggleCursorLocked;
            Master.ToggleMenuUIEvent -= ToggleCursorLocked;
        }

        private void ToggleCursorLocked() {
            _isCursorLocked = !_isCursorLocked;
            Cursor.visible = !_isCursorLocked;
            Cursor.lockState = _isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}