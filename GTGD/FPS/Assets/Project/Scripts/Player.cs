using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _timeForCharge;

    private float _timeForShot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && _timeForShot<=0) {
            _timeForShot = _timeForCharge;
            InstantiateBullet();
        }
        _timeForShot -= Time.deltaTime;
	}

    private void InstantiateBullet() {
        var bullet = Instantiate(_bulletPrefab, transform.TransformPoint(0, 0, 0.5f), transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
    }
}
