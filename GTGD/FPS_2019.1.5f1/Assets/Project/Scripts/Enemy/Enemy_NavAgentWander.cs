using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_NavAgentWander : Subscriber_Base<Enemy_Master> {

        [SerializeField] private float _wanderingRange = 10;
        private Vector3 _wanderingTarget;
        private float _checkRate;

        private void OnEnable() {
            SetInitialreferences();
            StartCoroutine(WanderingRoutine());
            Master.DieEvent += DisableThis;
        }

        private void OnDisable() {
            StopAllCoroutines();
            Master.DieEvent -= DisableThis;
        }

        private void SetInitialreferences() {
            _checkRate = Random.Range(0.3f, 0.4f);
        }

        private IEnumerator WanderingRoutine() {
            while (true) {
                CheckIfShouldWander();
                yield return new WaitForSeconds(_checkRate);
            }
        }

        private void CheckIfShouldWander() {
            if (Master.Target == null && !Master.IsOnRoute && !Master.IsNavMeshAgentPaused) {
                if (RandomWanderTarget(Master.MyTransform.position, _wanderingRange, out _wanderingTarget)) {
                    Master.MyNavMeshAgent.SetDestination(_wanderingTarget);
                    Master.IsOnRoute = true;
                    Master.CallWalkEvent();
                }
            }
        }

        private bool RandomWanderTarget(Vector3 center, float range, out Vector3 result) {
            var randomPos = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, 1.0f, NavMesh.AllAreas)) {
                result = hit.position;
                return true;
            }
            result = Vector3.zero;
            return false;
        }

        private void DisableThis() {
            enabled = false;
        }
    }
}