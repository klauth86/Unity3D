using UnityEngine;

public class Helicopter : MonoBehaviour {
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _isCalled;

    public void Call() {
        if (!_isCalled) {
            _isCalled = true;
            if (_audioSource)
                _audioSource.Play();
            if (_rigidbody)
                _rigidbody.velocity = new Vector3(0, 0, 50);
        }
    }
}
