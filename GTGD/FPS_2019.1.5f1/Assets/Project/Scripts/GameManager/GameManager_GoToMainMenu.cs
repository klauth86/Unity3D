using UnityEngine.SceneManagement;

namespace FPS.GameManager {
    public class GameManager_GoToMainMenu : Subscriber_Base<GameManager_Master> {
        private void OnEnable() {
            Master.GoToMenuSceneEvent += GoToMenuScene;
        }

        private void OnDisable() {
            Master.GoToMenuSceneEvent -= GoToMenuScene;
        }

        private void GoToMenuScene() {
            SceneManager.LoadScene(0);
        }
    }
}