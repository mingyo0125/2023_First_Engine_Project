using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : PoolableMono
{
    ParticleSystem _particle;

    public override void Init()
    {
        _particle = GetComponent<ParticleSystem>();

        _particle.Play();

        StartCoroutine(DestroyFX());
    }

    private IEnumerator DestroyFX()
    {
        yield return new WaitForSeconds(_particle.main.duration + 0.2f);
        PoolManager.Instance.Push(this);

    }
}
