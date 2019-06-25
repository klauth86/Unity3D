using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_NavAgentPause : Subscriber_Base<Enemy_Master> {

        [SerializeField] private float _pauseDuration = 1;

        private void OnEnable() {
            Master.DecreaseHealthEvent += PauseNavAgent;
            Master.DieEvent += DisableThis;
        }

        private void OnDisable() {
            Master.DecreaseHealthEvent -= PauseNavAgent;
            Master.DieEvent -= DisableThis;
            StopAllCoroutines();
        }

        private void PauseNavAgent(int param) {
            if (Master.MyNavMeshAgent && Master.MyNavMeshAgent.enabled) {
                Master.IsNavMeshAgentPaused = true;
                Master.MyNavMeshAgent.ResetPath();
            }
            StartCoroutine(PauseRoutine());
        }

        private IEnumerator PauseRoutine() {
            yield return new WaitForSeconds(_pauseDuration);
            Master.IsNavMeshAgentPaused = false;
        }

        private void DisableThis() {
            enabled = false;
        }
    }
}