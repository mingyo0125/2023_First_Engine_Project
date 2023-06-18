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

    public void SFXPlay(AudioClip clip)
    {
        GameObject soundclip = new GameObject(clip.name);
        AudioSource sound = soundclip.GetComponent<AudioSource>();
        sound.clip = clip;
        sound.Play();

        Destroy(soundclip, clip.length);
    }

}
