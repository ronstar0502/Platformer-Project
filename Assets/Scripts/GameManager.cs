using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab, bombPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField]private Vector3 spawnPosition;
    private float lastBoxSpawnTime;
    private float lastBombSpawnTime;
    private Spawner spawner;

    [SerializeField] private int scoreGoal = 10;
    private PlayerController player;

    [SerializeField]private GameObject victoryScreen, defeatScreen;
    void Start()
    {
        spawner = GetComponent<Spawner>();
        player = FindObjectOfType<PlayerController>();
        //player.gameObject.SetActive(true);
        victoryScreen.gameObject.SetActive(false);
        defeatScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        lastBoxSpawnTime = AttemptSpawn(boxPrefab, lastBoxSpawnTime, spawnDelay);
        lastBombSpawnTime = AttemptSpawn(bombPrefab, lastBombSpawnTime, spawnDelay*Random.Range(1.5f,4f));

        IsLevelFinished();
    }

    private float AttemptSpawn(GameObject prefab, float lastSpawnTime, float delay)
    {
        if (lastSpawnTime + delay < Time.time)
        {
            spawnPosition.x = Random.Range(-6f,6f);         
            spawner.Spawn(prefab,spawnPosition); 
            return Time.time; 
        }
        return lastSpawnTime; 
    }
    private void IsLevelFinished()
    {
        if (player.isDead)
        {
            DefeatScreen();
        }
        else if(player.score == scoreGoal)
        {
            VictoryScreen();
        }
    }
    private void VictoryScreen()
    {
        player.gameObject.SetActive(false);
        victoryScreen.SetActive(true);
        //Time.timeScale = 0;
    }

    private void DefeatScreen()
    {
        player.gameObject.SetActive(false);
        defeatScreen.SetActive(true);
        //Time.timeScale = 0;
    }

    


}
