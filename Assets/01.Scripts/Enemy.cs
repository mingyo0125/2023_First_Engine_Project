using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PoolableMono
{
    private float speed = 3f;
    private bool isStop = false;
    Vector3 _middleStop;

    Vector3 _endPos;

    public override void Init()
    {
        _middleStop = GameManager.Instance.MiddleTrm.position;
        _endPos = GameManager.Instance.EndTrm.position;
        _endPos = new Vector3(-4.5f, 5, 0);
    }

    private void FixedUpdate()
    {
        StartCoroutine(Fly());
    }

    private IEnumerator Fly()
    {
        if (isStop)
        {
            yield return new WaitForSeconds(3.5f);
            isStop = false;
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime);
        }

        if (transform.position.x <= _middleStop.x) { isStop = true; }
    }
}
