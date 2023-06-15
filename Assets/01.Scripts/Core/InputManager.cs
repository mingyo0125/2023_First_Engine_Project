using UnityEngine.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public UnityEvent FailEvent;
    public UnityEvent SuccessEvent;

    private int successArrowCount = 0;

    private void Update()
    {
        if (successArrowCount == ArrowSpawner.Instance._arrowList.Count && !ArrowSpawner.Instance.IsCreating)
        {
            if (EnemySpawner.Instance.CanSpawn)
            {
                successArrowCount = 0;
                EnemySpawner.Instance.EnemySpawnEvent?.Invoke();
                SuccessEvent?.Invoke();
            }
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
}

