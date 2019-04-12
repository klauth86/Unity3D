using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    [SerializeField] private Camera _camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer) {
            var input = new Vector3();
            input.x = CrossPlatformInputManager.GetAxis("Horizontal");
            if (input.x != 0)
                Debug.Log(input.x);
            input.y = 0f;
            input.z = CrossPlatformInputManager.GetAxis("Vertical");
            if (input.y != 0)
                Debug.Log(input.y);
            transform.Translate(input);
        }        
    }

    public override void OnStartLocalPlayer() {
        var cameraComp = _camera.GetComponent<Camera>();
        cameraComp.enabled = true;
    }
}
