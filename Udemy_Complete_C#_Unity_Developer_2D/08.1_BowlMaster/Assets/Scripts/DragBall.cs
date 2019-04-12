using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragBall : MonoBehaviour {
    #region Cache
    [SerializeField] private Ball _ball;
    #endregion

    #region State
    private float _beginTime;
    private Vector3 _beginPos;
    private float _velocityMagnitude = 16;
    #endregion

    public void DragStart() {
        _beginTime = Time.fixedTime;
        _beginPos = Input.mousePosition;
    }

    public void DragStop() {
        var _endTime = Time.fixedTime;
        var _endPos = Input.mousePosition;
        var touchVector = ((_endPos - _beginPos) / (_endTime - _beginTime)).normalized * _velocityMagnitude;
        if (_ball && _ball.CanMoveStart) {
            _ball.Launch(new Vector3(touchVector.x, 0, touchVector.y));
        }
    }

    public void MoveStart(float deltaX) {
        if (!_ball.CanMoveStart) return;
        _ball.transform.position = new Vector3(Mathf.Clamp(_ball.transform.position.x + deltaX, -0.50f, 0.50f),
            _ball.transform.position.y,
            _ball.transform.position.z);
    }
}
