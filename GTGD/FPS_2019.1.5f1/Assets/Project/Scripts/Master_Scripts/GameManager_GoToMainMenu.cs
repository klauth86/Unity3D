using UnityEngine.SceneManagement;

namespace FPS.Master {
    public class GameManager_GoToMainMenu : GameManager_Base {
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