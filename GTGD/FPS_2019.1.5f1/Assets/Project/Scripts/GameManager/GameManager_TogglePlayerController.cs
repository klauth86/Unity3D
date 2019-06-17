using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace FPS.GameManager {
    public class GameManager_TogglePlayerController : Subscriber_Base<GameManager_Master> {
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