using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSingleton : MonoBehaviour {

    public static GameSingleton Instance;

    [SerializeField] Text _defenseText;
    private int _defense;

    [SerializeField] Text _scoreText;
    private int _score;

    private AudioSource _audioSource;

    private Defender _defender;

    [SerializeField]
    private Transform _defendersGroup, _missilesGroup, _attackersGroup;

    private bool[,] Cells;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
            _audioSource = GetComponent<AudioSource>();
            Cells = new bool[5, 5];
        }
        else {
            gameObject.SetActive(false);
            Destroy(this);
        }
    }

    void Start() {
        UpdateScore();
        UpdateDefense();
    }

    public void AddToScore(int scoreToAdd) {
        _score += scoreToAdd;
        UpdateScore();
    }

    private void UpdateScore() {
        _scoreText.text = _score.ToString();
    }

    public void ReduceDefense(int defenseToSubtract) {
        _defense -= defenseToSubtract;
        UpdateDefense();
    }

    private void UpdateDefense() {
        _defenseText.text = _defense.ToString();
    }

    public void SpawnDefender(int x, int y) {
        if (_defender && !Cells[x, y]) {
            Cells[x, y] = true;
            var newDefender = Instantiate(_defender, new Vector3(x, y, 0), Quaternion.identity);
            newDefender.transform.parent = _defendersGroup;
        }
    }

    public void SetDefender(Defender defender) {
        _defender = defender;
    }

    public void PlayAudioClip(AudioClip clip) {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public Transform GetMissilesGroup() {
        return _missilesGroup;
    }
}