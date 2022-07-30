using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCount;
    [SerializeField] private int waveNumber = 1;
    [SerializeField] private GameObject powerUpPrefab;

    private const float SpawnRange = 9.0f;

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount != 0) return;

        waveNumber++;
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private static Vector3 GenerateSpawnPosition()
    {
        var spawnPositionX = Random.Range(-SpawnRange, SpawnRange);
        var spawnPositionZ = Random.Range(-SpawnRange, SpawnRange);

        return new Vector3(spawnPositionX, 0, spawnPositionZ);
    }
}