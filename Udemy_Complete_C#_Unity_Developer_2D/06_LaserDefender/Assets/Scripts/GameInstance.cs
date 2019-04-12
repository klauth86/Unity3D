using UnityEngine;

public class GameInstance : MonoBehaviour {
    public static GameInstance Instance = null;
    [Header("Config")]
    [SerializeField] private float _backgroundScroll = 0.5f;
    [Header("Stats")]
    [SerializeField] private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int delta)
    {
        _score += delta;
    }

    public void ResetScore()
    {
        _score = 0;
    }

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

    public float GetBackgroundScroll()
    {
        return _backgroundScroll;
    }

    public void ProcessFire(ISpaceShip ship, IWeapon weaponHit)
    {
        weaponHit.Hit();
        ship.Hit(weaponHit);
    }
}
