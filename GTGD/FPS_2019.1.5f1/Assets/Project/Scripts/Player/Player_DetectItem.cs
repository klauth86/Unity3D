using UnityEngine;
using FPS.GameManager;
using System.Collections;
using FPS.Item;

namespace FPS.Player {
    public class Player_DetectItem : Subscriber_Base<Player_Master> {
        [SerializeField] private float _detectRate;
        [SerializeField] private LayerMask _detectionLayer;
        [SerializeField] private Transform _rayCastPivot;

        [SerializeField] private float _detectRange = 3;
        [SerializeField] private float _detectRadius = 0.7f;
        private RaycastHit _hit;
        [SerializeField] private bool _hasPickupInRange;
        [SerializeField] private Transform _availablePickup;

        private float labelWidth = 200;
        private float labelHeight = 50;

        private void OnEnable() {
            Master.Manager_Master.InputKeyUpEvent += TryPickUp;
            StartCoroutine(DetectPickupsRoutine());
        }

        private void OnDisable() {
            Master.Manager_Master.InputKeyUpEvent -= TryPickUp;
            StopAllCoroutines();
        }

        private IEnumerator DetectPickupsRoutine() {
            while (true) {
                Detect();
                yield return new WaitForSeconds(_detectRate);
            }
        }

        private void Detect() {
            if (Physics.SphereCast(_rayCastPivot.position, _detectRadius, _rayCastPivot.forward, out _hit, _detectRange, _detectionLayer)) {
                _hasPickupInRange = true;
                _availablePickup = _hit.transform;
            }
            else {
                _hasPickupInRange = false;
            }
        }

        private void TryPickUp(KeyCode keyCode) {
            if (keyCode == KeyCode.E && _hasPickupInRange && _availablePickup != null && _availablePickup.root.tag != GameManager_References.PlayerTag && Time.timeScale > 0) {
                _availablePickup.GetComponent<Item_Master>().CallPickupEvent(_rayCastPivot);
            }
        }

        private void OnGUI() {
            if (_hasPickupInRange && _availablePickup != null) {
                GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2 - labelHeight / 2, labelWidth, labelHeight), _availablePickup.name);
            }
        }
    }
}
