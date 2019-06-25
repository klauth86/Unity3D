using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_NavAgentReachTarget : Subscriber_Base<Enemy_Master> {

        private float _checkRate;

        private void OnEnable() {
            SetInitialreferences();
            StartCoroutine(ReachEnemyRoutine());
            Master.DieEvent += DisableThis;
        }

        private void OnDisable() {
            StopAllCoroutines();
            Master.DieEvent -= DisableThis;
        }

        private void SetInitialreferences() {
            _checkRate = Random.Range(0.3f, 0.4f);
        }

        private IEnumerator ReachEnemyRoutine() {
            while (true) {
                CheckIfReachEnemy();
                yield return new WaitForSeconds(_checkRate);
            }
        }

        private void CheckIfReachEnemy() {
            if (Master.IsOnRoute) {
                if (Master.MyNavMeshAgent.remainingDistance < Master.MyNavMeshAgent.stoppingDistance) {
                    Master.IsOnRoute = false;
                    Master.CallReachNavTargetEvent();
                }
            }
        }

        private void DisableThis() {
            enabled = false;
        }
    }
}