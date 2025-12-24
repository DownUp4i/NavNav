using System.Collections;
using UnityEngine;

public class HealthKitSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnNearTo;
    [SerializeField] private float _raduisSpawner;
    [SerializeField] private HealthKit _healthKitPrefab;
    [SerializeField] private float _timeToSpawn;

    private void Start()
    {
        StartCoroutine(SpawnProcess());
    }

    private Vector3 SpawnPosition()
    {
        float randomX = Random.Range(_spawnNearTo.position.x - _raduisSpawner, _spawnNearTo.position.x + _raduisSpawner);
        float randomZ = Random.Range(_spawnNearTo.position.z - _raduisSpawner, _spawnNearTo.position.z + _raduisSpawner);

        return new Vector3(randomX, 0.2f, randomZ);
    }

    private IEnumerator SpawnProcess()
    {
        while (true)
        {
            SpawnPosition();
            Instantiate(_healthKitPrefab, SpawnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }

}
