using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;

    private const float SpawnRate = 1.0f;

    private IEnumerator Start()
    {
        yield return SpawnTarget();
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);

            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}