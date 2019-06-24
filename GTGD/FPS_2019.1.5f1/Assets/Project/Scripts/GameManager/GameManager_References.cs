using UnityEngine;

namespace FPS.GameManager {
    public class GameManager_References : MonoBehaviour {
        [SerializeField] private string _playerTag;
        [SerializeField] private string _enemyTag;
        [SerializeField] private GameObject _player;

        public static string PlayerTag;
        public static string EnemyTag;
        public static GameObject Player;

        // Start is called before the first frame update
        private void Awake() {
            PlayerTag = _playerTag;
            EnemyTag = _enemyTag;
            Player = _player;
        }
    }
}