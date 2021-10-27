using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private readonly Vector3 _spawnPos = new Vector3(25, 0, 0);
    private const float StartDelay = 2f;
    private const float RepeatRate = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, RepeatRate);
    }

    private GameObject SpawnObstacle()
    {
        return Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}