using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    public class Enemy_Master : MonoBehaviour {

        public bool IsOnRoute;
        public bool IsNavMeshAgentPaused;
        public Transform Target;

        private Transform _myTransform;
        public Transform MyTransform {
            get { return _myTransform ?? (_myTransform = GetComponent<Transform>()); }
        }

        private NavMeshAgent _myNavMeshAgent;
        public NavMeshAgent MyNavMeshAgent {
            get { return _myNavMeshAgent ?? (_myNavMeshAgent = GetComponent<NavMeshAgent>()); }
        }

        public event GameEventHandler DieEvent;
        public event GameEventHandler WalkEvent;
        public event GameEventHandler AttackEvent;

        public event GameEventHandler ReachNavTargetEvent;
        public event GameEventHandler LostNavTargetEvent;

        public event GameEventHandler<Transform> SetNavTargetEvent;

        public event GameEventHandler<int> IncreaseHealthEvent;
        public event GameEventHandler<int> DecreaseHealthEvent;

        public void CallDieEvent() {
            DieEvent?.Invoke();
        }

        public void CallWalkEvent() {
            WalkEvent?.Invoke();
        }

        public void CallAttackEvent() {
            AttackEvent?.Invoke();
        }

        public void CallReachNavTargetEvent() {
            ReachNavTargetEvent?.Invoke();
        }

        public void CallLostNavTargetEvent() {
            Target = null;
            LostNavTargetEvent?.Invoke();
        }

        public void CallSetNavTargetEvent(Transform target) {
            Target = target;
            SetNavTargetEvent?.Invoke(target);
        }

        public void CallIncreaseHealthEvent(int amount) {
            IncreaseHealthEvent?.Invoke(amount);
        }

        public void CallDecreaseHealthEvent(int amount) {
            DecreaseHealthEvent?.Invoke(amount);
        }
    }
}
