using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private const int SpawnRangeX = 20;
    private const float SpawnPosZ = 20f;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.S)) return;
        
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, SpawnPosZ);
        
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}