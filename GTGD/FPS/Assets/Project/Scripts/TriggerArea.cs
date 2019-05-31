using UnityEngine;

public class TriggerArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponentInChildren<Player>()) {
            Manager.Instance.ProcessGameEvent();
            Destroy(gameObject);
        }
    }
}
