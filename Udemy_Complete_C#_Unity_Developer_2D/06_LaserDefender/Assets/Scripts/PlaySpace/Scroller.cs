using UnityEngine;

public class Scroller : MonoBehaviour {
    [SerializeField]  Material _material;
    Vector2 _offset;

	// Use this for initialization
	void Start () {
        _material = GetComponent<Renderer>().material;
        _offset = new Vector2(0, GameInstance.Instance.GetBackgroundScroll());
	}
	
	// Update is called once per frame
	void Update () {
        _material.mainTextureOffset += _offset * Time.deltaTime;
	}
}
