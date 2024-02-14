using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private PlatformController[] _platformControllers;
    private void Start()
    {
        UpdateMultipleValuePlatform();
    }

    private void UpdateMultipleValuePlatform()
    {
        int randomIndex = UnityEngine.Random.Range(0, _platformControllers.Length);
        for (int i = 0; i < randomIndex; i++)
        {
            //_platformControllers[i].PlatformMultipleTypeEnum = (PlatformMultipleTypeEnum)UnityEngine.Random.Range(0, 5);
        }
    }
}
