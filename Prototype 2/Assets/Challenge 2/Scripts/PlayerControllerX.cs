using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool _isDogSpawned;
    
    private const float DogSpawnTimeInterval = .5f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !_isDogSpawned)
        {
            _isDogSpawned = true;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            Invoke(nameof(AllowDogSpawn), DogSpawnTimeInterval);
        }
    }

    private void AllowDogSpawn()
    {
        _isDogSpawned = false;
    }
}
