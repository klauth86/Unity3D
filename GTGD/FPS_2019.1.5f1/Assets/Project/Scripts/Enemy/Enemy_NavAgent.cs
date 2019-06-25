using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_NavAgent : Subscriber_Base<Enemy_Master> {

        private float _checkRate;

        private void OnEnable() {
            SetInitialreferences();
            StartCoroutine(ChaseEnemyRoutine());
            Master.DieEvent += DisableThis;
        }

        private void OnDisable() {
            StopAllCoroutines();
            Master.DieEvent -= DisableThis;
        }

        private void SetInitialreferences() {
            _checkRate = Random.Range(0.1f, 0.2f);
        }

        private IEnumerator ChaseEnemyRoutine() {
            while (true) {
                TryToChaseEnemy();
                yield return new WaitForSeconds(_checkRate);
            }
        }

        private void TryToChaseEnemy() {
            if (Master.MyNavMeshAgent != null && Master.MyNavMeshAgent.enabled &&
                Master.Target != null && !Master.IsNavMeshAgentPaused) {
                Master.MyNavMeshAgent.SetDestination(Master.Target.position);
                if (Master.MyNavMeshAgent.remainingDistance > Master.MyNavMeshAgent.stoppingDistance) {
                    Master.CallWalkEvent();
                    Master.IsOnRoute = true;
                }
            }
        }

        private void DisableThis() {
            enabled = false;
            if (Master.MyNavMeshAgent)
                Master.MyNavMeshAgent.enabled = false;
        }
    }
}