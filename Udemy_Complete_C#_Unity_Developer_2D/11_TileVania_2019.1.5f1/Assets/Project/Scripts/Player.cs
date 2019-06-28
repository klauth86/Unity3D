using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _velocity = 2f;
    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private float _climbSpeed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _bodyCollider;
    [SerializeField] private Collider2D _feetCollider;

    private bool _isAlive;
    private float _gravityScale;

    // Use this for initialization
    void Start()
    {
        _animator.SetBool("IsAlive", true);
        _isAlive = true;
        _gravityScale = _rigidbody2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive)
        {
            Run();
            Jump();
            FlipSprite();
            Climb();
        }
    }

    private void Climb()
    {
        if (_bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            _rigidbody2d.gravityScale = 0;
            var va = Input.GetAxis("Vertical");
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, va * _climbSpeed);
            _animator.SetBool("IsClimbing", va != 0);
        }
        else
        {
            _rigidbody2d.gravityScale = _gravityScale;
            _animator.SetBool("IsClimbing", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Fire1") && _feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpSpeed);
        }
    }

    private void Run()
    {
        var ha = Input.GetAxis("Horizontal");
        _rigidbody2d.velocity = new Vector2(Input.GetAxis("Horizontal") * _velocity, _rigidbody2d.velocity.y);
        _animator.SetBool("IsRunning", ha != 0);
    }

    private void FlipSprite()
    {
        var isRunning = Mathf.RoundToInt(Mathf.Sign(_rigidbody2d.velocity.x));
        transform.localScale = new Vector3(isRunning, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<DamageDealer>();
        if (enemy)
        {
            StartCoroutine(Die());
        }

        var exit = collision.gameObject.GetComponent<Exit>();
        if (exit)
        {
            exit.Success();
        }

        var coin = collision.gameObject.GetComponent<Pickup>();
        if (coin)
        {
            GameSession.Instance.Collect(coin);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var coin = collision.gameObject.GetComponent<Pickup>();
    //    if (coin)
    //    {
    //        GameSession.Instance.Collect(coin);
    //    }
    //}

    private IEnumerator Die()
    {
        _isAlive = false;
        _animator.SetBool("IsAlive", false);
        yield return new WaitForSeconds(2);
        GameSession.Instance.ProcessPlayerDie();
    }
}
