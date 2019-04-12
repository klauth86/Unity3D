using System.Collections;
using UnityEngine;

public class Attacker : Unit {
    const string IsAttacking = "IsAttacking";
    [SerializeField] private float _defaultVelocity;
    [SerializeField] private float _velocity;
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;

    public bool IsAttackingProp {
        set {
            _animator.SetBool(IsAttacking, value);
        }
    }

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
        SetWalkSpeed(_defaultVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var missile = collision.gameObject.GetComponent<Missile>();
        if (missile) {
            GetDamage(missile.GetDamage);
            Destroy(collision.gameObject);
        }

        var defender = collision.gameObject.GetComponent<DistanceDefender>();
        if (defender) {
            IsAttackingProp = true;
            SetWalkSpeed(0);
            StartFire(defender);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        var defender = collision.gameObject.GetComponent<DistanceDefender>();
        if (defender) {
            IsAttackingProp = false;
            SetWalkSpeed(_defaultVelocity);
        }
    }

    private Coroutine _fireCoroutine;

    public void StartFire(Defender defender) {
        if (_fireCoroutine == null)
            _fireCoroutine = StartCoroutine(Fire(defender));
    }

    public void StopFire() {
        if (_fireCoroutine != null)
            StopCoroutine(_fireCoroutine);
    }

    protected override void Die() {
        GameSingleton.Instance.AddToScore(_cost);
        base.Die();
    }

    IEnumerator Fire(Defender defender) {
        while (true) {
            defender.GetDamage(_damage);
            yield return new WaitForSeconds(_delay);
        }
    }

    public void SetWalkSpeed(float velocity) {
        _velocity = velocity;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * _velocity);
    }
}
