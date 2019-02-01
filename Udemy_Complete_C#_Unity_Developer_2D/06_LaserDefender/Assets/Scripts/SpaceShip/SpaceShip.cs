using UnityEngine;

public class SpaceShip : MonoBehaviour, ISpaceShip
{
    [SerializeField] protected float _velocity = 12f;
    [SerializeField] protected float _health = 500f;

    [SerializeField] protected GameObject _dieVfx;
    [SerializeField] protected AudioClip _dieSfx;

    public float GetVelocity()
    {
        return _velocity;
    }

    public float GetHealth()
    {
        return _health;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        var explosion = Instantiate(_dieVfx, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(_dieSfx, Camera.main.transform.position);
        Destroy(explosion, 1);
    }

    public void Hit(IWeapon hit)
    {
        _health -= hit.GetDamage();
        if (_health <= 0)
            Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameInstance.Instance.ProcessFire(this, other.gameObject.GetComponent<IWeapon>());
    }
}