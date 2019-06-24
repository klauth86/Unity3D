using FPS.GameManager;
using FPS.Player;
using UnityEngine;

namespace FPS.Item {
    [RequireComponent(typeof(Animator))]
    public class Item_Ammo : Subscriber_Base<Item_Master> {
        [SerializeField] private string _ammo;
        [SerializeField] private int _quantity;
        [SerializeField] private bool _isTriggerPickup;

        private void OnEnable() {
            if (_isTriggerPickup) {
                var collider = GetComponent<Collider>();
                if (collider)
                    collider.isTrigger = true;

                var rb = GetComponent<Rigidbody>();
                if (rb)
                    rb.isKinematic = true;
            }

            Master.PickupObjectEvent += TakeAmmo;
        }

        private void OnDisable() {
            Master.PickupObjectEvent -= TakeAmmo;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(GameManager_References.PlayerTag) && _isTriggerPickup)
                TakeAmmo();
        }

        private void TakeAmmo() {
            GameManager_References.Player.GetComponent<Player_Master>().CallPickupAmmoEvent(_ammo, _quantity);
            Object.Destroy(gameObject);
        }
    }
}