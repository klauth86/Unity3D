using FPS.GameManager;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private int _count;
    [SerializeField] private float _spawnActivationRange;
    private float _checkRate;

    private void OnEnable() {
        _checkRate = Random.Range(0.8f, 1.2f);
        StartCoroutine(DetectPlayerRoutine());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private IEnumerator DetectPlayerRoutine() {
        while(true) {
            if (Vector3.Distance(GameManager_References.Player.transform.position, transform.position) < _spawnActivationRange)
                Spawn();

            yield return new WaitForSeconds(_checkRate);
        }
    }

    private void Spawn() {
        for (int i = 0; i < _count; i++) {
            var pos = transform.position + Random.insideUnitSphere * 5;
            Instantiate(_objectToSpawn, pos, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
