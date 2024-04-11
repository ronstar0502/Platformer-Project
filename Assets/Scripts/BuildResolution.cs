using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// makes it so the build will work for each screen resolution of the user's screen
/// </summary>
public class BuildResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        DontDestroyOnLoad(gameObject);
    }
}
