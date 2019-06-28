using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    public static GameSession Instance;
    [SerializeField] public int _playerLives = 3;
    [SerializeField] public int _score = 0;

    [SerializeField] private Text _livesText;
    [SerializeField] private Text _scoreText;
    [SerializeField] AudioClip _collectCoinSfx;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _livesText.text = _playerLives.ToString();
        _scoreText.text = _score.ToString();
    }

    public void ProcessPlayerDie()
    {
        if (_playerLives > 1)
            TakeLife();
        else
            Reset();
    }

    private void TakeLife()
    {
        _playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    internal void Collect(Pickup coin)
    {
        _score++;
        Destroy(coin.gameObject);
        AudioSource.PlayClipAtPoint(_collectCoinSfx, Camera.main.transform.position);
    }
}
