using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _pathPrefab;
    [SerializeField] float _spawnFrequency = 0.5f;
    [SerializeField] float _spawnRandomLevel = 0.5f;
    [SerializeField] int NumberOfEnemies = 5;
    [SerializeField] float Speed = 2f;

    public GameObject GetEnemyPrefab() { return _enemyPrefab; }
    public List<Transform> GetWayPoints() {
        var result = new List<Transform>();
        foreach (Transform child in _pathPrefab.transform)
        {
            result.Add(child);
        }
        return result;
    }
    public float GetSpawnFrequency() { return _spawnFrequency; }
    public float GetSpawnRandomLevel() { return _spawnRandomLevel; }
    public int GetNumberOfEnemies() { return NumberOfEnemies; }
    public float GetSpeed() { return Speed; }

}
