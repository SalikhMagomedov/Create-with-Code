using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject powerUp;

    private const float XSpawnRange = 8.0f;
    private const float YSpawn = .75f;
    private const float ZEnemySpawn = 12.0f;
    private const float ZPowerUpRange = 5.0f;
    private const float PowerUpSpawnTime = 5.0f;
    private const float EnemySpawnTime = 1.0f;
    private const float StartDelay = 1.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), StartDelay, EnemySpawnTime);
        InvokeRepeating(nameof(SpawnPowerUp), StartDelay, PowerUpSpawnTime);
    }

    private void SpawnEnemy()
    {
        var randomX = Random.Range(-XSpawnRange, XSpawnRange);
        var randomIndex = Random.Range(0, enemies.Length);

        var spawnPosition = new Vector3(randomX, YSpawn, ZEnemySpawn);
        Instantiate(enemies[randomIndex], spawnPosition, Quaternion.identity);
    }

    private void SpawnPowerUp()
    {
        var randomX = Random.Range(-XSpawnRange, XSpawnRange);
        var randomZ = Random.Range(-ZPowerUpRange, ZPowerUpRange);

        var spawnPosition = new Vector3(randomX, YSpawn, randomZ);

        Instantiate(powerUp, spawnPosition, Quaternion.identity);
    }
}