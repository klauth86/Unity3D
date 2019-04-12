using UnityEngine;

public class Board : MonoBehaviour {
    private void OnMouseDown() {
        var clickPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        var worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        GameSingleton.Instance.SpawnDefender(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y));
    }
}