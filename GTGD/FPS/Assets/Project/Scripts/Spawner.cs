using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _enemyPrefab;

	// Use this for initialization
	void Start () {
        Manager.Instance.GameEvent += () => {
            foreach (var item in _points) {
                Instantiate(_enemyPrefab, new Vector3(item.position.x, _enemyPrefab.transform.localScale.y / 2, item.position.z), Quaternion.identity);
            }
        };
	}
}
