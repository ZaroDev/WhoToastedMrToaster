using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 2;
        Application.targetFrameRate = 72;
        Debug.Log($"Target frame rate {Application.targetFrameRate}");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
