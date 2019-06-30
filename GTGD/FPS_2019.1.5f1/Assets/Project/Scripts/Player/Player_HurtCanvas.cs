using System.Collections;
using UnityEngine;

namespace FPS.Player {
    public class Player_HurtCanvas : Subscriber_Base<Player_Master> {
        [SerializeField] private GameObject _hurtCanvas;
        [SerializeField] private int _hurtCanvasExposition = 2;

        private void OnEnable() {
            Master.DecreaseHealthEvent += OnChangeHealth;
        }

        private void OnDisable() {
            Master.DecreaseHealthEvent -= OnChangeHealth;
        }

        private void OnChangeHealth(int changeHealth) {
            StopAllCoroutines();
            _hurtCanvas.SetActive(true);
            StartCoroutine(HurtRoutine());
        }

        private IEnumerator HurtRoutine() {
            yield return new WaitForSeconds(_hurtCanvasExposition);
            _hurtCanvas.SetActive(false);
        }
    }
}