using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SFX : PoolableMono
{
    AudioSource _audioSource;

    public override void Init()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.Play();

        StartCoroutine(DestroyAudio());
    }

    private IEnumerator DestroyAudio()
    {
        yield return new WaitForSeconds(_audioSource.clip.length + 0.2f);
        PoolManager.Instance.Push(this);
    }
}
