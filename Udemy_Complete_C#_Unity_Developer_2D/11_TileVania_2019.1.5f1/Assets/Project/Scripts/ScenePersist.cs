using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

    public static ScenePersist Instance;

    private int _startBuildIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        _startBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
        var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentBuildIndex != _startBuildIndex)
            Destroy(gameObject);
    }
}
