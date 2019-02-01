using System.Collections;
using UnityEngine;

public class DistanceDefender : Defender {
    const string IsAttacking = "IsAttacking";

    [SerializeField] private Transform _launcher;
    [SerializeField] private GameObject _missile;
    [SerializeField] private float _delay;

    public bool IsAttackingProp {
        set {
            _animator.SetBool(IsAttacking, value);
        }
    }

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private Coroutine _fireCoroutine;

    public void StartFire() {
        if (_fireCoroutine == null)
            _fireCoroutine = StartCoroutine(Fire());
    }

    public void StopFire() {
        if (_fireCoroutine != null)
            StopCoroutine(_fireCoroutine);
    }

    IEnumerator Fire() {
        while (true) {
            var newMissile = Instantiate(_missile, _launcher.position, Quaternion.identity);
            newMissile.transform.parent = GameSingleton.Instance.GetMissilesGroup();
            yield return new WaitForSeconds(_delay);
        }
    }
}
