using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] Helicopter _heli;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] bool _reSpawn;
    public bool ReSpawn {
        get { return _reSpawn; }
        set { _reSpawn = value; }
    }

    void Start() {
        _reSpawn = false;        
    }

    void Update() {
        if (ReSpawn) {
            Spawn();
            ReSpawn = false;
        }
    }

    public void Spawn() {
        var i = Random.Range(0, _spawnPoints.Length);
        transform.position = _spawnPoints[i].position;
    }

    public void OnFindClearArea() {
        _heli.Call();
    }
}
