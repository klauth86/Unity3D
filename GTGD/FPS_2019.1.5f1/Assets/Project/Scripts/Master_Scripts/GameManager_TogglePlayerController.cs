using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace FPS.Master {
    public class GameManager_TogglePlayerController : GameManager_Base {
        [SerializeField]private FirstPersonController _playerController;

        private void OnEnable() {
            Master.ToggleMenuUIEvent += TogglePlayerController;
            Master.ToggleInventoryUIEvent += TogglePlayerController;
        }

        private void OnDisable() {
            Master.ToggleMenuUIEvent -= TogglePlayerController;
            Master.ToggleInventoryUIEvent -= TogglePlayerController;
        }

        private void TogglePlayerController() {
            if (_playerController) {
                _playerController.enabled = !_playerController.enabled;
            }
            else {
                Debug.LogWarning("MenuUI is not set!");
            }
        }
    }
}