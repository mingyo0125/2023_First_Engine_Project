using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using TMPro;

public class ArrowSpawner : MonoBehaviour
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

    [SerializeField]
    private bool isCreating;

    private IEnumerator InitArrow()
    {
        _succesArrowCount = 0;
        _arrowList.Clear();

        for (int i = 0; i < _arrowNum; i++)
        {
            int rand = UnityEngine.Random.Range(1, 5);
            isCreating = true;
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

            _arrowList[i].transform.position = new Vector3(_arrowPosition.x + (3 * i), 0, 0);
            Debug.Log($"Name: {_arrowList[i].name} Pos:{ _arrowList[i].transform.position}");
            yield return new WaitForSeconds(0.1f);
        }

        isCreating = false;
    }

    private void Update()
    {
        if(isCreating) { return; }

        if (_succesArrowCount == _arrowList.Count)
        {
            SuccesEvent?.Invoke();
        }
    }

    public void ClickButton(string keyCode)
    {
        if (keyCode == _arrowList[_succesArrowCount].keyCode.ToString())
        {
            PoolManager.Instance.Push(_arrowList[_succesArrowCount]);
            _succesArrowCount++;
        }
        else
        {
            FailEvent?.Invoke();
        }
    }    

    public void Succes()
    {
        text.SetText(_roundCount.ToString());
        _roundCount++;

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

    public void ReSetArrow()
    {
        for (int i = 0; i < _arrowNum; i++)
        {
            Debug.Log("»ç¶óÁü2");
            PoolManager.Instance.Push(_arrowList[i]);
        }

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

}
