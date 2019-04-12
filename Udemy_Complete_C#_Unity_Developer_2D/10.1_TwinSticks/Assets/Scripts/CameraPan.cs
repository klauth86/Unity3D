using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPan : MonoBehaviour {

    [SerializeField] private Transform _target;

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
        var hr = CrossPlatformInputManager.GetAxis("RHoriz");
        var vr = CrossPlatformInputManager.GetAxis("RVert");
        transform.RotateAround(_target.position, _target.right, hr * 30.0f * Time.deltaTime);
        transform.RotateAround(_target.position, _target.up, vr * 30.0f * Time.deltaTime);
    }

    private void LateUpdate() {
       transform.LookAt(_target);
    }
}
