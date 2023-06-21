using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent FailEvent;
    public UnityEvent SuccessEvent;
    //public Action EnemyDieAction;

    [SerializeField]
    private int succesArrowCount = 0;

    [SerializeField]
    private Transform FirePoint;

    private void Update()
    {
        if (succesArrowCount == ArrowSpawner.Instance._arrowNum && !ArrowSpawner.Instance.IsCreating)
        {
            FX fX = PoolManager.Instance.Pop("MuzzleFX") as FX;
            fX.transform.position = FirePoint.position;
            SoundManager.Instance.SFXPlay("Gun");

            succesArrowCount = 0;
            EnemySpawner.Instance.CurEnemy.Die();
            //if (ArrowSpawner.Instance.RoundCount == 5)
            //{
            //    //ArrowSpawner.Instance.RoundCount = 1;
            //    Debug.Log("1");
            //}
            SuccessEvent?.Invoke();
        }
    }

    public void ClickButton(string keyCode)
    {
        if (ArrowSpawner.Instance.IsCreating) { return; }

        if (keyCode == ArrowSpawner.Instance._arrowList[succesArrowCount].keyCode.ToString())
        {
            PoolManager.Instance.Push(ArrowSpawner.Instance._arrowList[succesArrowCount]);
            VisibleArrowManager.Instance.VisibleArrowList[succesArrowCount].gameObject.SetActive(false);
            succesArrowCount++;
        }
        else
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

}
