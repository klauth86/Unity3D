using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS.Player {
    public class Player_AmmoBox : Subscriber_Base<Player_Master> {

        [System.Serializable]
        class AmmoType {
            public string Name;
            public int MaxQuantity;
            public int Quantity;

            public AmmoType(string name, int maxq, int q) {
                Name = name;
                MaxQuantity = maxq;
                Quantity = q;
            }
        }

        [SerializeField] List<AmmoType> Ammos = new List<AmmoType>();

        private void OnEnable() {
            Master.PickupAmmoEvent += OnPickupAmmo;
        }

        private void OnDisable() {
            Master.PickupAmmoEvent -= OnPickupAmmo;
        }

        private void OnPickupAmmo(string name, int quantity) {
            var current = Ammos.FirstOrDefault(a => a.Name == name);
            if (current != null) {
                current.Quantity += quantity;
                if (current.Quantity > current.MaxQuantity)
                    current.Quantity = current.MaxQuantity;
                Master.CallChangeAmmoEvent();
            }
            else
                Debug.Log("Illegal Ammo type name!");
        }       
    }
}
