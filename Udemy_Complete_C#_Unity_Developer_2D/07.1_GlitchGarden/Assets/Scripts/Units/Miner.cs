using System.Collections;
using UnityEngine;

public class Miner : Defender {
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _delay;

    // Use this for initialization
    void Start() {
        StartCoroutine(MineStars());
    }

    IEnumerator MineStars() {
        while (true) {
            GameSingleton.Instance.AddToScore(_scoreToAdd);
            yield return new WaitForSeconds(_delay);
        }
    }
}
