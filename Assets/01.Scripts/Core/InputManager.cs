using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("InputManager 2°³");
        }
        Instance = this;
    }

    public UnityEvent FailEvent;
    public UnityEvent SuccessEvent;
    //public Action EnemyDieAction;

    [SerializeField]
    public int SuccesArrowCount = 0;

    [SerializeField]
    private Transform FirePoint;

    public int Score;

    private void Update()
    {
        if (SuccesArrowCount == ArrowSpawner.Instance._arrowNum && !ArrowSpawner.Instance.IsCreating)
        {
            FX fX = PoolManager.Instance.Pop("MuzzleFX") as FX;
            fX.transform.position = FirePoint.position;
            SoundManager.Instance.SFXPlay("Gun");

            Score++;
            PlayerPrefs.SetInt("Score", Score);

            SuccesArrowCount = 0;
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

        if (keyCode == ArrowSpawner.Instance._arrowList[SuccesArrowCount].keyCode.ToString())
        {
            PoolManager.Instance.Push(ArrowSpawner.Instance._arrowList[SuccesArrowCount]);
            VisibleArrowManager.Instance.VisibleArrowList[SuccesArrowCount].gameObject.SetActive(false);
            SuccesArrowCount++;
        }
        else
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

}
