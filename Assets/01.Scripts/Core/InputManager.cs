using UnityEngine.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public UnityEvent FailEvent;
<<<<<<< HEAD
    public UnityEvent SuccessEvent;
=======
    public UnityEvent SuccesEvent;
    public Action EnemyDieEvent;

    Enemy curEnemy;

    [SerializeField]
    private int succesArrowCount = 0;
>>>>>>> parent of 717cd9e (바꾸기전)

    private int successArrowCount = 0;

    private void Update()
    {
        if (successArrowCount == ArrowSpawner.Instance._arrowList.Count && !ArrowSpawner.Instance.IsCreating)
        {
<<<<<<< HEAD
            if (EnemySpawner.Instance.CanSpawn)
            {
                successArrowCount = 0;
                EnemySpawner.Instance.EnemySpawnEvent?.Invoke();
                SuccessEvent?.Invoke();
            }
=======
            succesArrowCount = 0;
            EnemyDieEvent?.Invoke();
            SuccesEvent?.Invoke();
            EnemySpawner.Instance.EnemySpawnEvent?.Invoke();
>>>>>>> parent of 717cd9e (바꾸기전)
        }
    }

    public void ClickButton(string keyCode)
    {
        if (ArrowSpawner.Instance.IsCreating)
            return;

        if (keyCode == ArrowSpawner.Instance._arrowList[successArrowCount].keyCode.ToString())
        {
            PoolManager.Instance.Push(ArrowSpawner.Instance._arrowList[successArrowCount]);
            successArrowCount++;
        }
        else
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }
<<<<<<< HEAD
=======

    public void FindEnemy()
    {
        if(EnemyDieEvent != null) { EnemyDieEvent -= curEnemy.DieAnimationStart; }
        curEnemy = FindAnyObjectByType<Enemy>();
        EnemyDieEvent += curEnemy.DieAnimationStart;
    }
>>>>>>> parent of 717cd9e (바꾸기전)
}

