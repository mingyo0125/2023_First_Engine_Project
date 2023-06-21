using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("SoundManager 2°³");
        }
        Instance = this;
    }

    public void SFXPlay(string name)
    {
        PoolManager.Instance.Pop(name);
    }

}
