using UnityEngine;

public class SpaceShipWithWeapon : SpaceShip
{
    [SerializeField] protected GameObject _firePrefab;
    [SerializeField] protected AudioClip _fireSfx;
    [SerializeField] protected float _fireVelocity;

    protected void FireOut(int sign =1)
    {
        var laserObject = Instantiate(_firePrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(_fireSfx, Camera.main.transform.position);
        laserObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, sign * _fireVelocity);
    }
}