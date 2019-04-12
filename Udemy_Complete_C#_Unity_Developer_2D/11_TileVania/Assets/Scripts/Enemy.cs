using UnityEngine;

public class Enemy : DamageDealer {
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _velocity = 2f;

    private int directionOfMovement=1;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        _rigidbody2d.velocity = new Vector2(directionOfMovement*_velocity, _rigidbody2d.velocity.y);
    }

    private void FlipSprite()
    {
        var isRunning = Mathf.RoundToInt(Mathf.Sign(_rigidbody2d.velocity.x));
        transform.localScale = new Vector3(isRunning, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        directionOfMovement = -directionOfMovement;
    }
}
