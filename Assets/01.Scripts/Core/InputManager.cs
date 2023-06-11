using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent FailEvent;
    public UnityEvent SuccesEvent;
    public Action EnemyDieEvent;

    Enemy curEnemy;

    [SerializeField]
    private int succesArrowCount = 0;


    private void Update()
    {
        if (succesArrowCount == ArrowSpawner.Instance._arrowList.Count && !ArrowSpawner.Instance.IsCreating)
        {
            succesArrowCount = 0;
            EnemyDieEvent?.Invoke();
            SuccesEvent?.Invoke();
        }
    }

    public void ClickButton(string keyCode)
    {
        if (ArrowSpawner.Instance.IsCreating) { return; }
        if (keyCode == ArrowSpawner.Instance._arrowList[succesArrowCount].keyCode.ToString())
        {
            PoolManager.Instance.Push(ArrowSpawner.Instance._arrowList[succesArrowCount]);
            succesArrowCount++;
        }
        else
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

    public void FindEnemy()
    {
        if(EnemyDieEvent != null) { EnemyDieEvent -= curEnemy.DieAnimationStart; }
        curEnemy = FindAnyObjectByType<Enemy>();
        EnemyDieEvent += curEnemy.DieAnimationStart;
    }
}
