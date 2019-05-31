using Base;
using UnityEngine;

public class Manager : MonoBehaviour {

    public event GameEvent GameEvent;

    public static Manager Instance;

    private void OnEnable() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnDisable() {
        Instance.GameEvent = null;
        Instance = null;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ProcessGameEvent() {
        Debug.Log("ProcessGameEvent");
        if (GameEvent != null)
            GameEvent();
    }
}
