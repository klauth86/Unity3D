using FPS.GameManager;
using System.Collections;
using UnityEngine;

namespace FPS.Enemy {
    [RequireComponent(typeof(Animator))]
    public class Enemy_EnemyDetection : Subscriber_Base<Enemy_Master> {

        [SerializeField] private Transform _head;
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private LayerMask _sightLayerMask;

        [SerializeField] private float _detectionRange;

        private float _checkRate;
        private RaycastHit _hit;


        private void OnEnable() {
            SetInitialreferences();
            StartCoroutine(CarryOutDetectionRoutine());
            Master.DieEvent += DisableThis;
        }

        private void OnDisable() {
            StopAllCoroutines();
            Master.DieEvent -= DisableThis;
        }

        private void SetInitialreferences() {
            if (_head == null)
                _head = Master.MyTransform;

            _checkRate = Random.Range(0.8f, 1.2f);
        }

        private IEnumerator CarryOutDetectionRoutine() {
            while(true) {
                var colliders = Physics.OverlapSphere(Master.MyTransform.position, _detectionRange, _playerLayerMask);
                if (colliders != null && colliders.Length >0)
                    foreach (var collider in colliders) {
                        if (collider.CompareTag(GameManager_References.PlayerTag)) {
                            if (CanSeePotentialTarget(collider.transform))
                                break;
                        }
                    }
                else {
                    CanSeePotentialTarget(null);
                }
                yield return new WaitForSeconds(_checkRate);
            }
        }

        private bool CanSeePotentialTarget(Transform target) {
            if (target && Physics.Linecast(_head.position, target.position, out _hit, _sightLayerMask)) {
                if (_hit.transform == target) {
                    Master.CallSetNavTargetEvent(target);
                    return true;
                }
            }
            Master.CallLostNavTargetEvent();
            return false;
        }

        private void DisableThis() {
            enabled = false;
        }
    }
}