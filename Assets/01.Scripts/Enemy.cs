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

    Animator _animator;
    Rigidbody _rigidbody;

    public override void Init()
    {
        isStop = false;
        _middleStop = GameManager.Instance.MiddleTrm.position;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Approximately(transform.position.x, _middleStop.x) || transform.position.x < _middleStop.x) { isStop = true; }
        Fly();
    }

    private void Fly()
    {
        if (isStop)
        {
            speed = 0;
        }
        else
        {
            speed = 3f;
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }

    }

    public void Die()
    {
        StartCoroutine(EnemyDieCorou());
    }

    private IEnumerator EnemyDieCorou()
    {
        _rigidbody.velocity = new Vector3(transform.position.x, transform.position.y * - 5f, transform.position.z);
        yield return new WaitForSeconds(1f);
        EnemySpawner.Instance.EnemyKill();
    }
}
