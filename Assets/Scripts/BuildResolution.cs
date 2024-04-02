using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        DontDestroyOnLoad(gameObject);
    }
}
