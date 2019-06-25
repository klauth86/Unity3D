using FPS.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_Attack : Subscriber_Base<Enemy_Master> {

        private Transform _target;

        [SerializeField] private float _attackRange = 3.5f;
        [SerializeField] private int _attackDamage = 10;
        [SerializeField] private float _attackRate = 1;

        private void OnEnable() {
            Master.DieEvent += DisableThis;
            Master.SetNavTargetEvent += SetAttackTarget;
            Master.LostNavTargetEvent += UnsetAttackTarget;
            StartCoroutine(TryToAttackRoutine());
        }

        private void OnDisable() {
            Master.DieEvent -= DisableThis;
            Master.SetNavTargetEvent -= SetAttackTarget;
            Master.LostNavTargetEvent -= UnsetAttackTarget;
            StopAllCoroutines();
        }

        private void SetAttackTarget(Transform target) {
            _target = target;
        }

        private void UnsetAttackTarget() {
            _target = null;
        }

        private IEnumerator TryToAttackRoutine() {
            while (true) {
                if (_target != null && Vector3.Distance(Master.MyTransform.position, _target.position) < _attackRange) {
                    Master.MyTransform.LookAt(new Vector3(_target.position.x, Master.MyTransform.position.y, _target.position.z));
                    Master.CallAttackEvent();
                    Master.IsOnRoute = false;
                }

                yield return new WaitForSeconds(_attackRate);
            }
        }

        public void OnAttack() {
            if (_target != null && Vector3.Distance(Master.MyTransform.position, _target.position) < _attackRange) {
                var direction = _target.position - Master.MyTransform.position;
                var dot = Vector3.Dot(Master.MyTransform.forward, direction);
                var pm = _target.gameObject.GetComponent<Player_Master>();
                if (dot > 0.5 && pm) {
                    pm.CallDecreaseHealthEvent(-_attackDamage);
                }
            }
        }

        private void DisableThis() {
            enabled = false;
        }
    }
}