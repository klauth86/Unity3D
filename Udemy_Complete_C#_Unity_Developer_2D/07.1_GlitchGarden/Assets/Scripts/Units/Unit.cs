using UnityEngine;

public abstract class Unit : MonoBehaviour {
    [SerializeField] protected int _hitPoints;
    [SerializeField] protected int _cost;

    [SerializeField] private GameObject _dieVfx;
    [SerializeField] private AudioClip _dieSfx;

    public int GetCost() {
        return _cost;
    }

    public void GetDamage(int damage) {
        if (_hitPoints > damage)
            _hitPoints -= damage;
        else
            Die();
    }

    protected virtual void Die() {
        Destroy(gameObject);
        if (_dieVfx) {
            var vfx = Instantiate(_dieVfx, transform.position, transform.rotation);
            Destroy(vfx, 1);
        }
        if (_dieSfx)
            GameSingleton.Instance.PlayAudioClip(_dieSfx);
    }
}