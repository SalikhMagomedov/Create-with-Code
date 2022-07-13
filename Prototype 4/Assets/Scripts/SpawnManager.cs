using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private const float SpawnRange = 9.0f;

    private void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }

    private static Vector3 GenerateSpawnPosition()
    {
        var spawnPositionX = Random.Range(-SpawnRange, SpawnRange);
        var spawnPositionZ = Random.Range(-SpawnRange, SpawnRange);

        return new Vector3(spawnPositionX, 0, spawnPositionZ);
    }
}