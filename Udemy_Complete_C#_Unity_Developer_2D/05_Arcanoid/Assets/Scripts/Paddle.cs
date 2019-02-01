using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float _screenWidthInUnits = 16f;
    [SerializeField]
    private float _minXInUnits = 1f;
    [SerializeField]
    private float _maxXInUnits = 15f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var newX = Mathf.Clamp(Input.mousePosition.x / Screen.width * _screenWidthInUnits, _minXInUnits, _maxXInUnits);
        transform.position = new Vector2(newX, transform.position.y);
    }
}