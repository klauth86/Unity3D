using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 _initTransformPosition;

    #region Cache
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _strikeSfx;
    #endregion

    #region State
    [SerializeField] private bool _canMoveStart;
    public bool CanMoveStart {
        get { return _canMoveStart; }
        set { _canMoveStart = value; }
    }
    #endregion

    // Use this for initialization
    void Start() {
        CanMoveStart = true;
        _rigidbody.useGravity = false;
        _initTransformPosition = transform.position;
    }

    public void Launch(Vector3 velocity) {
        CanMoveStart = false;
        _rigidbody.useGravity = true;
        _rigidbody.velocity = velocity;
        _audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision) {
        if (_strikeSfx)
            AudioSource.PlayClipAtPoint(_strikeSfx, ((Camera)FindObjectOfType(typeof(Camera))).transform.position);
    }

    public void Reset() {
        transform.position = _initTransformPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        CanMoveStart = true;
    }
}
