using UnityEngine;

namespace FPS.Item {
    [RequireComponent(typeof(Animator))]
    public class Item_Animator : Subscriber_Base<Item_Master> {
        private Animator _animator;
        public Animator Animator {
            get { return _animator ?? (_animator = GetComponent<Animator>()); }
        }

        private void OnEnable() {
            Master.ThrowObjectEvent += DisableAnimator;
            Master.PickupObjectEvent += EnableAnimator;
        }

        private void OnDisable() {
            Master.ThrowObjectEvent -= DisableAnimator;
            Master.PickupObjectEvent -= EnableAnimator;
        }

        private void EnableAnimator() {
            if (Animator)
                Animator.enabled = true;
        }

        private void DisableAnimator() {
            if (Animator)
                Animator.enabled = false;
        }
    }
}