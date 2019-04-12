using UnityEngine;

public class Shredder : MonoBehaviour {
    private void OnTriggerExit(Collider other) {
        var pin = other.gameObject.GetComponent<Pin>();
        if (pin)
            Destroy(pin.gameObject);
    }
}
