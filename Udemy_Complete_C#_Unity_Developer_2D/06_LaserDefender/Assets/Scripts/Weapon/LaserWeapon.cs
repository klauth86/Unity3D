using UnityEngine;

public class LaserWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] int _damage = 100;

    public int GetDamage()
    {
        return _damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
