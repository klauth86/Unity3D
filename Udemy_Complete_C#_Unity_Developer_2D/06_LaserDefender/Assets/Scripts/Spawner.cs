using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private List<WaveConfig> _configs;


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnAllWaves());
	}

    private IEnumerator SpawnAllWaves()
    {
        while(true)
        {
            for (int i = 0; i < _configs.Count; i++)
            {
                var currentWave = _configs[i];
                yield return StartCoroutine(SpawnAllEnemies(currentWave));
            }
        }
    }

    private IEnumerator SpawnAllEnemies(WaveConfig config)
    {
        for (int i = 0; i < config.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(config.GetEnemyPrefab(), 
                config.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<PathFinding>().SetWaveConfig(config);
            yield return new WaitForSeconds(config.GetSpawnFrequency());
        }
    }
}
