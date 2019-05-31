using UnityEngine;

public class TriggerArea : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponentInChildren<Player>()) {
            Manager.Instance.ProcessGameEvent();
            Destroy(gameObject);
        }
    }
}
