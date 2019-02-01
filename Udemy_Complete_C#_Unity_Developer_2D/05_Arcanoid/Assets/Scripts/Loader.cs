using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel+1);
    }

    public void LoadPrevLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel-1);
    }

    public void LoadStart()
    {
        SceneManager.LoadScene(0);
        Config.Instance.ResetScore();
    }
}
