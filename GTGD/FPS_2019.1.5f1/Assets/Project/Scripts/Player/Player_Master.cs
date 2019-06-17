using FPS.GameManager;
using UnityEngine;

namespace FPS.Player {
    public class Player_Master : MonoBehaviour {
        public event GameEventHandler ChangeInventoryEvent;
        public event GameEventHandler EmptyHandsEvent;
        public event GameEventHandler ChangeAmmoEvent;

        public event GameEventHandler<string, int> PickupAmmoEvent;

        public event GameEventHandler<int> IncreaseHealthEvent;
        public event GameEventHandler<int> DecreaseHealthEvent;

        private GameManager_Master _manager_Master;
        public GameManager_Master Manager_Master {
            get { return _manager_Master ?? (_manager_Master = FindObjectOfType<GameManager_Master>()); }
        }

        private GameManager_ToggleInventoryUI _manager_ToggleInventoryUI;
        public GameManager_ToggleInventoryUI Manager_ToggleInventoryUI {
            get { return _manager_ToggleInventoryUI ?? (_manager_ToggleInventoryUI = FindObjectOfType<GameManager_ToggleInventoryUI>()); }
        }

        public void CallChangeInventoryEvent() {
            ChangeInventoryEvent?.Invoke();
        }

        public void CallEmptyHandsEvent() {
            EmptyHandsEvent?.Invoke();
        }

        public void CallChangeAmmoEvent() {
            ChangeAmmoEvent?.Invoke();
        }

        public void CallPickupAmmoEvent(string ammoName, int quantity) {
            PickupAmmoEvent?.Invoke(ammoName, quantity);
        }

        public void CallIncreaseHealthEvent(int hp) {
            IncreaseHealthEvent?.Invoke(hp);
        }

        public void CallDecreaseHealthEvent(int hp) {
            DecreaseHealthEvent?.Invoke(hp);
        }

        private void Start() {
            CallChangeInventoryEvent();
        }
    }
}