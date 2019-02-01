using UnityEngine;

public class Enemy : SpaceShipWithWeapon, IWeapon
{
    [SerializeField] private float _shotCounter;
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private int _scorePoint;

    private void Start()
    {
        _shotCounter = Random.Range(_minTime, _maxTime);
    }

    private void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            Fire();
            _shotCounter = Random.Range(_minTime, _maxTime);
        }
    }

    private void Fire()
    {
        FireOut(-1);
    }

    public void Hit()
    {
        Die();
    }

    public int GetDamage()
    {
        return 1000;
    }

    public override void Die()
    {
        base.Die();
        GameInstance.Instance.AddToScore(_scorePoint);
    }
}
