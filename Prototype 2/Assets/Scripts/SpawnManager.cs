using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private const float SpawnRangeX = 20f;
    private const float SpawnPosZ = 20f;
    private const float StartDelay = 2f;
    private const float SpawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), StartDelay, SpawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, SpawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}