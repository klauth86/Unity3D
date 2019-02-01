using UnityEngine;

public class CameraControl : MonoBehaviour {

    #region Cache
    [SerializeField] private Ball _ball;
    #endregion

    #region State
    private Vector3 _offset;
    #endregion

    // Use this for initialization
    void Start() {
        _offset = transform.position - _ball.transform.position;
    }

    // Update is called once per frame
    void Update() {
        var delta = (_ball.transform.position + _offset);
        if (delta.z < 17 && delta.y > -2)
            transform.position = delta;
    }
}
