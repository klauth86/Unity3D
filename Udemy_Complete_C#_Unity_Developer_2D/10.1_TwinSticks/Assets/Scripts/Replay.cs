using UnityEngine;

public class Replay : MonoBehaviour {

    private const int _bufferSize = 1000;
    private MyKeyframe[] _buffer = new MyKeyframe[_bufferSize];
    private int _maxIndex;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private GameManager _gameManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_gameManager.RecordingMode)
            RecordFame();
        else
            Playback();
    }

    private void RecordFame() {
        _rigidBody.isKinematic = false;
        int index = Time.frameCount % _bufferSize;
        _buffer[index] = new MyKeyframe(Time.time, transform.position, transform.rotation);
        _maxIndex = index + 1;
    }

    private void Playback() {
        _rigidBody.isKinematic = true;
        int index = (Time.frameCount % _bufferSize) % _maxIndex;
        if (_buffer[index] != null) {
            transform.position = _buffer[index].Pos;
            transform.rotation = _buffer[index].Rot;
        }
    }
}

/// <summary>
/// Structure for storing data for Replay system
/// </summary>
public class MyKeyframe {
    public readonly float Time;
    public readonly Vector3 Pos;
    public readonly Quaternion Rot;

    public MyKeyframe(float time, Vector3 pos, Quaternion rot) {
        Time = time;
        Pos = pos;
        Rot = rot;
    }
}