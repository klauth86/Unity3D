using UnityEngine.SceneManagement;

namespace FPS.GameManager {
    public class GameManager_RestartLevel : Subscriber_Base<GameManager_Master> {
        private void OnEnable() {
            Master.RestartLevelEvent += RestartLevel;
        }

        private void OnDisable() {
            Master.RestartLevelEvent -= RestartLevel;
        }

        private void RestartLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}