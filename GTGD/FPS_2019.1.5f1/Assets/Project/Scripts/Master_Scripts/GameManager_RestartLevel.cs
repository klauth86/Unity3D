using UnityEngine.SceneManagement;

namespace FPS.Master {
    public class GameManager_RestartLevel : GameManager_Base {
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