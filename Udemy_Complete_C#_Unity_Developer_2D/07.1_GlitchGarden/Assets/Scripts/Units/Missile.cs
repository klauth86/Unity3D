using UnityEngine;

public class Missile : MonoBehaviour {
    [SerializeField] private float _velocity;
    [SerializeField] private float _angleVelocity;
    [SerializeField] private int _damage;
	
    public int GetDamage {
        get { return _damage; }
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * _velocity, Space.World);
        transform.Rotate(0, 0, -Time.deltaTime * _angleVelocity);
    }
}
