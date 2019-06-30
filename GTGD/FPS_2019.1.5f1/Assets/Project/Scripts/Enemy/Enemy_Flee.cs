using FPS.GameManager;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_Flee : Subscriber_Base<Enemy_Master> {

        private bool _isFleeing;
        private Enemy_NavAgent _navAgent;
        private NavMeshAgent _navMeshAgent;
        private NavMeshHit _hit;
        private Transform _fleeTarget;
        private Vector3 _runDirection;
        private Vector3 _playerDirection;
        private float _fleeRange = 25;
        private float _checkRate;

        private void OnEnable() {
            SetInitialreferences();
            StartCoroutine(CheckRoutine());
            Master.DieEvent += DisableThis;
            Master.SetNavTargetEvent += SetFleeTarget;
            Master.LowHealthEvent += IShouldFlee;
            Master.HighHealthEvent += IShouldStopFlee;
        }

        private void OnDisable() {
            StopAllCoroutines();
            Master.DieEvent -= DisableThis;
            Master.SetNavTargetEvent -= SetFleeTarget;
            Master.LowHealthEvent -= IShouldFlee;
            Master.HighHealthEvent -= IShouldStopFlee;
        }

        private IEnumerator CheckRoutine() {
            while(true) {
                CheckIfIShouldFlee();
                yield return new WaitForSeconds(_checkRate);
            }
        }

        private void SetInitialreferences() {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navAgent = GetComponent<Enemy_NavAgent>();
            _checkRate = Random.Range(0.3f, 0.4f);
        }

        private void SetFleeTarget(Transform target) {
            _fleeTarget = target;
        }

        void CheckIfIShouldFlee() {
            if (_isFleeing) {
                if(_fleeTarget != null && !Master.IsOnRoute && !Master.IsNavMeshAgentPaused) {
                    if (FleeTarget(out _runDirection) && Vector3.Distance(transform.position, _fleeTarget.position)<_fleeRange) {
                        _navMeshAgent.SetDestination(_runDirection);
                        Master.CallWalkEvent();
                        Master.IsOnRoute = true;
                    }
                }
            }
        }

        void IShouldFlee() {
            _isFleeing = true;
            _navAgent.enabled = false;
        }

        void IShouldStopFlee() {
            _isFleeing = false;
            _navAgent.enabled = true;
        }

        bool FleeTarget(out Vector3 result) {
            _playerDirection = transform.position - GameManager_References.Player.transform.position;
            var checkPos = transform.position + _playerDirection;
            
            if (NavMesh.SamplePosition(checkPos, out _hit, 1.0f, NavMesh.AllAreas)) {
                result = _hit.position;
                return true;
            }
            else {
                result = transform.position;
                return false;
            }
        }

        void DisableThis() {
            enabled = false;
        }
    }
}