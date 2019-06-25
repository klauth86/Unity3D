using UnityEngine;

namespace FPS.Enemy {
    [RequireComponent(typeof(Animator))]
    public class Enemy_Animation : Subscriber_Base<Enemy_Master> {

        private Animator _animator;
        public Animator Animator {
            get { return _animator ?? (_animator = GetComponent<Animator>()); }
        }

        private void OnEnable() {
            Master.DieEvent += DisableAnimation;
            Master.WalkEvent += SetAnimationToWalk;
            Master.ReachNavTargetEvent += SetAnimationToIdle;
            Master.AttackEvent += SetAnimationToAttack;
            Master.DecreaseHealthEvent += SetAnimationToStruck;
        }

        private void OnDisable() {
            Master.DieEvent -= DisableAnimation;
            Master.WalkEvent -= SetAnimationToWalk;
            Master.ReachNavTargetEvent -= SetAnimationToIdle;
            Master.AttackEvent -= SetAnimationToAttack;
            Master.DecreaseHealthEvent -= SetAnimationToStruck;
        }

        private void SetAnimationToIdle() {
            if (Animator && Animator.enabled) {
                Animator.SetBool("IsPursuing", false);
            }
        }

        private void SetAnimationToWalk() {
            if (Animator && Animator.enabled) {
                Animator.SetBool("IsPursuing", true);
            }
        }

        private void SetAnimationToStruck(int amount) {
            if (Animator && Animator.enabled) {
                Animator.SetTrigger("Struck");
            }
        }

        private void SetAnimationToAttack() {
            if (Animator && Animator.enabled) {
                Animator.SetTrigger("Attack");
            }
        }

        private void DisableAnimation() {
            Animator.enabled = false;
        }
    }
}