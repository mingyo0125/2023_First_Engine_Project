using DG.Tweening;
using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PoolableMono
{
    float amplitude;

    public override void Init()
    {
        transform.SetParent(GameObject.Find("Main Camera").transform, false);
    }

    public void Die()
    {
        StartCoroutine(EnemyDieCorou());
    }

    private IEnumerator EnemyDieCorou()
    {
        transform.DOMoveY(-1f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);
        EnemySpawner.Instance.EnemyKill();
    }

    private void Update()
    {
        amplitude = Mathf.Sin(Time.time) * 0.1f - 0.35f;
        transform.localPosition = new Vector3(0.1f, amplitude, 3.7f);
    }
}
