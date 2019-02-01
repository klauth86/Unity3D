using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField] private float _standingThreshold = 5f;
    [SerializeField] private float _raiseHeight = 0.7f;

    public static int CountStanding() {
        int counter = 0;
        foreach (var item in FindObjectsOfType<Pin>()) {
            if (item.IsStanding())
                counter++;
        }
        return counter;
    }

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Min(Mathf.Abs(rotationInEuler.x + 90), Mathf.Abs(270 - rotationInEuler.x), Mathf.Abs(450 + rotationInEuler.x));
        float tiltInZ = Mathf.Min(Mathf.Abs(rotationInEuler.z), Mathf.Abs(360 - rotationInEuler.z), Mathf.Abs(360 + rotationInEuler.z));

        if (tiltInX < _standingThreshold && tiltInZ < _standingThreshold) {
            return true;
        }
        else {
            return false;
        }
    }

    public void Raise() {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        transform.Translate(new Vector3(0, _raiseHeight, 0), Space.World);
    }

    public void Lower() {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        transform.Translate(new Vector3(0, -_raiseHeight, 0), Space.World);
    }
}
