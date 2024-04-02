using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public void Spawn(GameObject spawnable,Vector3 position,int amount)
    {
        for (int i = 1; i <= amount; i++)
        {
            position.x = Random.Range(-8f, 8f);
            GameObject spawnedObject = Instantiate(spawnable, position, Quaternion.identity, parent);
            spawnedObjects.Add(spawnedObject);
        }
    }   
    
    public void DestroyAllObjects()
    {
        for(int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        spawnedObjects.Clear();
    }

}
