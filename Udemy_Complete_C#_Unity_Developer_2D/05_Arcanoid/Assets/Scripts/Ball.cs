using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Paddle _paddle1;

    [SerializeField]
    private AudioClip[] _audios;

    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    private Vector2 _initialDistance;

    private bool _hasStarted;

    // Use this for initialization
    void Start()
    {
        _initialDistance = transform.position - _paddle1.transform.position;
        _hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;
            _rigidbody2D.velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = new Vector2(_paddle1.transform.position.x, _paddle1.transform.position.y) + _initialDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasStarted)
        {
            var clip = _audios[Random.Range(0, _audios.Length - 1)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
