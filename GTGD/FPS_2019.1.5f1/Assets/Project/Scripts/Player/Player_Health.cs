using UnityEngine;
using UnityEngine.UI;

namespace FPS.Player {
    public class Player_Health : Subscriber_Base<Player_Master> {
        [SerializeField] private Text _healthText;
        [SerializeField] private int _health;

        private void Awake() {
            UpdateUI();
        }

        private void OnEnable() {
            Master.IncreaseHealthEvent += OnChangeHealth;
            Master.DecreaseHealthEvent += OnChangeHealth;
        }

        private void OnDisable() {
            Master.IncreaseHealthEvent -= OnChangeHealth;
            Master.DecreaseHealthEvent -= OnChangeHealth;
        }

        private void OnChangeHealth(int changeHealth) {
            _health += changeHealth;
            if (_health <= 0) {
                _health = 0;
                Master.Manager_Master.CallGameOverEvent();
            }
            if (_health >100) {
                _health = 100;
            }
            UpdateUI();
        }

        private void UpdateUI() {
            if (_healthText) {
                _healthText.text = _health.ToString();
            }
            else {
                Debug.LogWarning("Health Text is not set in the Inspector.");
            }
        }
    }
}
