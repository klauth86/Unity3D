using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] Defender _defender;

    private void Start() {
        foreach (var item in FindObjectsOfType<DefenderButton>()) {
            var sr = item.GetComponent<SpriteRenderer>();
            sr.color = new Color32(41, 41, 41, 255);
        }
    }

    private void OnMouseDown() {
        foreach (var item in FindObjectsOfType<DefenderButton>()) {
            var sr = item.GetComponent<SpriteRenderer>();
            sr.color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        GameSingleton.Instance.SetDefender(_defender);
    }
}
