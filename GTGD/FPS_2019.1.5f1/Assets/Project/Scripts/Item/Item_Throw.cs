using FPS.GameManager;
using System;
using System.Collections;
using UnityEngine;

namespace FPS.Item {
    public class Item_Throw : Subscriber_Base<Item_Master> {
        [SerializeField] private Transform _myTransform;
        [SerializeField] private Rigidbody _myRigidBody;
        [SerializeField] private float _throwForce;
        [SerializeField] private Vector3 _throwDirection;
        [SerializeField] private bool _canBeThrown;    

        private void OnEnable() {
            Master.Player_Master.Manager_Master.InputKeyUpEvent += OnInputKeyUp;
        }

        private void OnDisable() {
            Master.Player_Master.Manager_Master.InputKeyUpEvent -= OnInputKeyUp;
        }

        private void OnInputKeyUp(KeyCode keyCode) {
            if (keyCode == KeyCode.F && _canBeThrown && Time.timeScale > 0 && _myTransform.root.CompareTag(GameManager_References.PlayerTag)) {
                ThrowAction();
            }
        }

        private void ThrowAction() {
            _throwDirection = _myTransform.root.forward;
            _myTransform.parent = null;
            Master.CallThrowObjectEvent();
            AddForce();
        }

        private void AddForce() {
            _myRigidBody.AddForce(_throwDirection * _throwForce, ForceMode.Impulse);
        }
    }
}