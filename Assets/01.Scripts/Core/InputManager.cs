using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent FailEvent;
    public UnityEvent SuccesEvent;
    //public Action EnemyDieAction;

    [SerializeField]
    private int succesArrowCount = 0;


    private void Update()
    {
        if (succesArrowCount == ArrowSpawner.Instance._arrowNum && !ArrowSpawner.Instance.IsCreating)
        {
            EnemySpawner.Instance.CurEnemy.DieAnimationStart();

            succesArrowCount = 0;
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
        //if(EnemyDieAction != null) { EnemyDieAction -= curEnemy.DieAnimationStart; }
        //EnemyDieAction += curEnemy.DieAnimationStart;
    }
}
