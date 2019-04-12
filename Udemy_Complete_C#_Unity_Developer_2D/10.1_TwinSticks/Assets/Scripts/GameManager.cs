using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool RecordingMode;

    // Use this for initialization
    void Start () {
        RecordingMode = true;
    }
	
	// Update is called once per frame
	void Update () {
        RecordingMode = !CrossPlatformInputManager.GetButton("Fire1");
	}
}
