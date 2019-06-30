using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_Health : Subscriber_Base<Enemy_Master> {
        [SerializeField] private int _max = 100;
        [SerializeField] private int _health = 100;

        private void OnEnable() {
            Master.DecreaseHealthEvent += DecreaseHealth;
            Master.IncreaseHealthEvent += IncreaseHealth;
        }

        private void OnDisable() {
            Master.DecreaseHealthEvent -= DecreaseHealth;
            Master.IncreaseHealthEvent -= IncreaseHealth;
        }

        private void DecreaseHealth(int amount) {
            _health -= amount;
            if (_health < 0) {
                _health = 0;
                Master.CallDieEvent();
                Destroy(gameObject, Random.Range(10, 20));
            }
            else if (_health / _max < 0.5f)
                Master.CallLowHealthEvent();
        }


        private void IncreaseHealth(int amount) {
            _health += amount;
            if (_health > _max) {
                _health = _max;
            }
            if (_health / _max > 0.5f)
                Master.CallHighHealthEvent();
        }
    }
}