using System.Collections;
using UnityEngine;

public class HealthKitSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnNearTo;
    [SerializeField] private float _raduisSpawner;
    [SerializeField] private HealthKit _healthKitPrefab;
    [SerializeField] private float _timeToSpawn;

    private Coroutine _coroutineSpawner;
    private bool _isSpawning;

    private void Awake()
    {
        _isSpawning = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _isSpawning = !_isSpawning;

        if (_isSpawning && _coroutineSpawner == null)
            _coroutineSpawner = StartCoroutine(SpawnProcess());
    } 

    private Vector3 SetSpawnPosition()
    {
        float randomX = Random.Range(_spawnNearTo.position.x - _raduisSpawner, _spawnNearTo.position.x + _raduisSpawner);
        float randomZ = Random.Range(_spawnNearTo.position.z - _raduisSpawner, _spawnNearTo.position.z + _raduisSpawner);

        return new Vector3(randomX, 0.2f, randomZ);
    }

    private IEnumerator SpawnProcess()
    {
        while (_isSpawning)
        {
            SetSpawnPosition();
            Instantiate(_healthKitPrefab, SetSpawnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(_timeToSpawn);
        }

        _coroutineSpawner = null;
    }

}
