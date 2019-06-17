using FPS.Player;
using UnityEngine;

namespace FPS.Item {
    public class Item_Master : MonoBehaviour {
        public event GameEventHandler PickupObjectEvent;
        public event GameEventHandler ThrowObjectEvent;
        public event GameEventHandler<Transform> PickupEvent;

        private Player_Master _player_Master;
        public Player_Master Player_Master {
            get { return _player_Master ?? (_player_Master = FindObjectOfType<Player_Master>()); }
        }

        public void CallPickupObjectEvent() {
            Player_Master.CallChangeInventoryEvent();
            PickupObjectEvent?.Invoke();
        }

        public void CallThrowObjectEvent() {
            Player_Master.CallEmptyHandsEvent();
            Player_Master.CallChangeInventoryEvent();
            ThrowObjectEvent?.Invoke();
        }

        public void CallPickupEvent(Transform item) {
            PickupEvent?.Invoke(item);
        }
    }
}