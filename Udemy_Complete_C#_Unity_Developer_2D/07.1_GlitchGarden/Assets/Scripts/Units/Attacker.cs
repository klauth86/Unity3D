using UnityEngine;

public abstract class Attacker : Unit {
    [SerializeField] private float _velocity;

    private void OnCollisionEnter2D(Collision2D collision) {

    }

    protected override void Die() {
        GameSingleton.Instance.AddToScore(_cost);
        base.Die();
    }
}
