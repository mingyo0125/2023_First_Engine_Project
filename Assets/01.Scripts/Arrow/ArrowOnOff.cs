using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ArrowOnOff : MonoBehaviour
{
    public UnityEvent FailEvent;

    [SerializeField]
    private List<Arrow> _arrowList = new List<Arrow>();
    [SerializeField]
    private Vector3 _arrowPosition;
    [SerializeField]
    private int _arrowNum = 5;

    int _arrowCount = 0;
    int[] _randArr = new int[5];

    private void InitArrow(int _rand)
    {
        int rand = _rand;

        switch (rand)
        {
            case 1:
                Arrow left = PoolManager.Instance.Pop("Left") as Arrow;
                _arrowList.Add(left);
                break;
            case 2:
                Arrow right = PoolManager.Instance.Pop("Right") as Arrow;
                _arrowList.Add(right);
                break;
            case 3:
                Arrow up = PoolManager.Instance.Pop("Up") as Arrow;
                _arrowList.Add(up);
                break;
            case 4:
                Arrow down = PoolManager.Instance.Pop("Down") as Arrow;
                _arrowList.Add(down);
                break;
        }

        for (int i = 0; i < _arrowList.Count; i++)
        {
            _arrowList[i].transform.position = new Vector3(_arrowPosition.x + (3 * i), 0, 0);
        }

    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(_arrowList[_arrowCount].keyCode))
            {
                PoolManager.Instance.Push(_arrowList[_arrowCount]);
                _arrowCount++;
            }
            else if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
            {
                FailEvent?.Invoke();
            }
        }

        if (_arrowCount == _arrowList.Count)
        {
            _arrowCount = 0;
            _arrowList.Clear();

            for (int i = 0; i < _arrowNum; i++)
            {
                int rand = UnityEngine.Random.Range(1, 5);
                _randArr[i] = rand;
                InitArrow(rand);
            }
        }

    }

    public void ReSetArrow()
    {
        for (int i = 0; i < _arrowList.Count; i++)
        {
            PoolManager.Instance.Push(_arrowList[i]);
        }

        _arrowCount = 0;
        _arrowList.Clear();

        for (int i = 0; i < _arrowNum; i++)
        {
            InitArrow(_randArr[i]);
        }
    }

}