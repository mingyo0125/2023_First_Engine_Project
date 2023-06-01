using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField]
    private int _arrowNum = 5;

    public List<Arrow> _arrowList = new List<Arrow>();
    [SerializeField]
    private Transform _arrowPosition;

    [SerializeField]
    int roundCount = 0;
    private bool isCreating;

    int temp;

    #region prop

    public bool IsCreating => isCreating;
    public int RoundCount => roundCount;

    #endregion

    private IEnumerator InitArrow()
    {
        isCreating = true;

        _arrowList.Clear();

        for (int i = 0; i < _arrowNum; i++)
        {
            int rand = UnityEngine.Random.Range(1, 5);
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

            _arrowList[i].transform.position = new Vector3(_arrowPosition.transform.position.x + 1.3f * i, 5, 0);
            yield return new WaitForSeconds(0.1f);
        }

        isCreating = false;
    }

    public void Succes()
    {
        //text.SetText(_rouCount.ToString());
        roundCount++;

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

    public void ReSetArrow()
    {
        for (int i = 0; i < _arrowList.Count; i++)
        {
            PoolManager.Instance.Push(_arrowList[i]);
        }

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

}
