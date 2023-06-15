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

    Enemy curEnemy;

    [SerializeField]
    private int succesArrowCount = 0;


    private void Update()
    {
        if (succesArrowCount == ArrowSpawner.Instance._arrowList.Count && !ArrowSpawner.Instance.IsCreating)
        {
            if (curEnemy != null) { curEnemy.DieAnimationStart(); }
            Debug.Log(EnemySpawner.Instance.CanSpawn);

            if (EnemySpawner.Instance.CanSpawn)
            {
                succesArrowCount = 0;
                EnemySpawner.Instance.EnemySpawnEvent?.Invoke();
                SuccesEvent?.Invoke();
            }
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
        curEnemy = FindAnyObjectByType<Enemy>();
        //EnemyDieAction += curEnemy.DieAnimationStart;
    }
}
