using UnityEngine;

public class ClearArea : MonoBehaviour {
    [SerializeField] private float _timeSinceLastTrigger = 0.0f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        _timeSinceLastTrigger += Time.deltaTime;
        if (_timeSinceLastTrigger > 1 && Time.realtimeSinceStartup > 10f)
            SendMessageUpwards("OnFindClearArea");
    }

    private void OnTriggerStay(Collider other) {
        _timeSinceLastTrigger = 0;
    }
}
