using UnityEngine;
using UnityEngine.UI;

public class Config : MonoBehaviour
{
    public static Config Instance;

    [Range(0.1f, 10)]
    [SerializeField]
    private float _timeScale = 1f;

    [SerializeField]
    private int _scorePerBlock = 100;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = _timeScale;
    }

    public void AddToScore()
    {
        _score += _scorePerBlock;
        _scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        Block.Count = 0;
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}
