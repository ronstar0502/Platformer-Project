using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(GameObject spawnable,Vector3 position)
    {
        Instantiate(spawnable, position, Quaternion.identity);
    }
}
