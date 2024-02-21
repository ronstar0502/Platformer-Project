using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab, bombPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField]private Vector3 spawnPosition;
    private float lastSpawnTime;
    private Spawner spawner;
    void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    void Update()
    {
        // Assuming spawnDelay is defined elsewhere in your class
        lastSpawnTime = AttemptSpawn(foodPrefab, lastSpawnTime, spawnDelay);
        
    }

    // Method to attempt spawning an object and return the updated last spawn time
    float AttemptSpawn(GameObject prefab, float lastSpawnTime, float delay)
    {
        if (lastSpawnTime + delay < Time.time)
        {
            spawnPosition.x = Random.Range(-6f,6f);
            spawner.Spawn(prefab,spawnPosition); // Assuming this method is defined elsewhere
            return Time.time; // Update the last spawn time
        }
        return lastSpawnTime; // No spawn, return the old time
    }


}
