using System.Collections;
using UnityEngine;

public class Player : SpaceShipWithWeapon {
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    [SerializeField] protected float _fireReTime;
    [SerializeField] protected LevelLoader _levelLoader;

    // Use this for initialization
    void Start () {
        SetUpBoundaries();
	}

    private void SetUpBoundaries()
    {
        var camera = Camera.main;
        _minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        _maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        _minY = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        _maxY = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update () {
        Move();
        Fire();
	}

    public override void Die()
    {
        base.Die();
        _levelLoader.LoadGameOver();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime * _velocity;
        var newX = Mathf.Clamp(transform.position.x + deltaX, _minX, _maxX);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _velocity;
        var newY = Mathf.Clamp(transform.position.y + deltaY, _minY, _maxY);

        transform.position = new Vector2(newX, newY);
    }

    protected Coroutine _coroutine;

    protected void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _coroutine = StartCoroutine(FireCoroutine());
        }
        if (Input.GetButtonUp("Fire1") && _coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    protected IEnumerator FireCoroutine()
    {
        while (true)
        {
            FireOut();
            yield return new WaitForSeconds(_fireReTime);
        }
    }
}
