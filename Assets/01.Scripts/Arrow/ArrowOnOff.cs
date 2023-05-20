using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR;
using TMPro;

public class ArrowOnOff : MonoBehaviour
{
    public UnityEvent FailEvent;
    public UnityEvent SuccesEvent;

    [SerializeField]
    private TextMeshPro text;
    [SerializeField]
    private List<Arrow> _arrowList = new List<Arrow>();
    [SerializeField]
    private Vector3 _arrowPosition;
    [SerializeField]
    private int _arrowNum = 5;

    [SerializeField]
    int _succesArrowCount = 0;
    int _roundCount = 0;
    int[] _randArr = new int[5];

    [SerializeField]
    private bool isCreating;

    private IEnumerator InitArrow()
    {
        for(int i = 0; i< _arrowNum; i++)
        {
            isCreating = true;
            switch (_randArr[i])
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

            _arrowList[i].transform.position = new Vector3(_arrowPosition.x + (3 * i), 0, 0);
            yield return new WaitForSeconds(0.1f);
            isCreating = false;
        }
    }

    private void Update()
    {
        if(isCreating) { return; }

        if (_succesArrowCount == _arrowList.Count)
        {
            SuccesEvent?.Invoke();
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(_arrowList[_succesArrowCount].keyCode) && !isCreating)
            {
                PoolManager.Instance.Push(_arrowList[_succesArrowCount]);
                _succesArrowCount++;
            }
            else if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && !isCreating)
            {
                FailEvent?.Invoke();
            }
        }

    }

    public void Succes()
    {
        text.SetText(_roundCount.ToString());
        _roundCount++;


        _succesArrowCount = 0;
        _arrowList.Clear();

        for (int i = 0; i < _arrowNum; i++)
        {
            int rand = UnityEngine.Random.Range(1, 5);
            _randArr[i] = rand;
        }

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

    public void ReSetArrow()
    {
        for (int i = 0; i < _arrowNum; i++)
        {
            PoolManager.Instance.Push(_arrowList[i]);
        }

        _succesArrowCount = 0;
        _arrowList.Clear();

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

}
