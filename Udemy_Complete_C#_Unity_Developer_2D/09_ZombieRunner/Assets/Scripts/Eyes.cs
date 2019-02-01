using UnityEngine;

public class Eyes : MonoBehaviour {
    [SerializeField] private Camera _eyes;
    [SerializeField] private float _minFieldOfView;
    [SerializeField] private float _maxFieldOfView;

    // Use this for initialization
    void Start() {
        _minFieldOfView = _eyes.fieldOfView/10;
        _maxFieldOfView = _eyes.fieldOfView;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Zoom"))
            Zoom();
        else
            Zoom(true);
    }

    private void Zoom(bool backwards = false) {
        _eyes.fieldOfView = Mathf.Clamp((backwards ? 1.5f : 0.6f) * _eyes.fieldOfView, _minFieldOfView, _maxFieldOfView);
    }
}
