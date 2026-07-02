using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject _zombiePrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay = 5f;
    [SerializeField] private int _maxZombieAlive = 5;

    private float _spawnTimer;
    private int _currentZombieAlive;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnDelay)
        {
            _spawnTimer = 0f;

            if (_currentZombieAlive < _maxZombieAlive)
            {
                SpawnZombie();
            }
        }
    }

    void SpawnZombie()
    {
        int _randomIndex = Random.Range(0, _spawnPoints.Length);
        Transform _spawnPoint = _spawnPoints[_randomIndex];

        Vector3 randomOffset = new Vector3(
            Random.Range(-2f, 2f),
            0,
            Random.Range(-2f, 2f)
        );

        Vector3 spawnPos = _spawnPoint.position + randomOffset;

        Instantiate(_zombiePrefab, spawnPos, Quaternion.identity);
    }

    public void ZombieDied()
    {
        _currentZombieAlive--;

        if (_currentZombieAlive < 0)
        {
            _currentZombieAlive = 0;
        }
    }
}