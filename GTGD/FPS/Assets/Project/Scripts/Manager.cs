using Base;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public event GameEvent GameEvent;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private Text _messageText;

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
        ShowMessage("Hello there! There is a treasure chest right on this level! So be quick and gold will stick!");
        GameEvent += () => { ShowMessage("Poor Adventurer!  Now yuu'll see our wrath!"); };
    }

    // Update is called once per frame
    void Update() {

    }

    public void ProcessGameEvent() {
        Debug.Log("ProcessGameEvent");
        if (GameEvent != null)
            GameEvent();
    }

    public void ShowMessage(string message) {
        StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message) {
        _messageText.text = message;
        _messagePanel.SetActive(true);
        yield return new WaitForSeconds(2);

        var image = _messagePanel.GetComponent<Image>();
        for (int i = 1; i <= 100; i++) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, (100.0f - i) / 200);
            yield return new WaitForSeconds(0.01f);
        }
        _messagePanel.SetActive(false);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
    }
}
