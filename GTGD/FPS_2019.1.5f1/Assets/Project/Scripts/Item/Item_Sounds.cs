using System;
using FPS.GameManager;
using UnityEngine;

namespace FPS.Item {
    public class Item_Sounds : Subscriber_Base<Item_Master> {
        [SerializeField] private float _volume;
        [SerializeField] private AudioClip _throwSfx;

        private void OnEnable() {
            Master.ThrowObjectEvent += PlayThrowSfx;
        }

        private void OnDisable() {
            Master.ThrowObjectEvent -= PlayThrowSfx;
        }

        private void PlayThrowSfx() {
            if (_throwSfx)
                AudioSource.PlayClipAtPoint(_throwSfx, transform.position, _volume);
        }
    }
}