using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab, bombPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField]private Vector3 spawnPosition;
    private float lastBoxSpawnTime;
    private float lastBombSpawnTime;
    private Spawner spawner;
    void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    void Update()
    {
        lastBoxSpawnTime = AttemptSpawn(boxPrefab, lastBoxSpawnTime, spawnDelay);
        lastBombSpawnTime = AttemptSpawn(bombPrefab, lastBombSpawnTime, spawnDelay*Random.Range(1.5f,4f));
    }

    float AttemptSpawn(GameObject prefab, float lastSpawnTime, float delay)
    {
        if (lastSpawnTime + delay < Time.time)
        {
            spawnPosition.x = Random.Range(-6f,6f);         
            spawner.Spawn(prefab,spawnPosition); 
            return Time.time; 
        }
        return lastSpawnTime; 
    }


}
