using UnityEngine;

public class DayNight : MonoBehaviour {

    [SerializeField]private float _angleVelocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(1, 0, 0), _angleVelocity * Time.deltaTime);
	}
}
