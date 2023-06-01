using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent FailEvent;
    public UnityEvent SuccesEvent;

    [SerializeField]
    private int succesArrowCount = 0;

    ArrowSpawner _arrowSpawner;

    private void Awake()
    {
        _arrowSpawner = GetComponent<ArrowSpawner>();
    }

    private void Update()
    {
        if (succesArrowCount == _arrowSpawner._arrowList.Count && !_arrowSpawner.IsCreating)
        {
            succesArrowCount = 0;
            SuccesEvent?.Invoke();
        }
    }

    public void ClickButton(string keyCode)
    {
        if (keyCode == _arrowSpawner._arrowList[succesArrowCount].keyCode.ToString())
        {
            PoolManager.Instance.Push(_arrowSpawner._arrowList[succesArrowCount]);
            succesArrowCount++;
        }
        else
        {
            succesArrowCount = 0;
            FailEvent?.Invoke();
        }
    }
}
