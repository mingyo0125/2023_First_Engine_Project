  using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnOff : MonoBehaviour
{
    [SerializeField]
    private List<Arrow> _arrowList = new List<Arrow>();
    [SerializeField]
    private Vector3 _arrowPosition;

    int _arrowCount = 0;

    void Start()
    {
        CreateArrow();
    }

    private void CreateArrow()
    {
        for(int i = 0; i < 5; i++)
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
        }

        for (int i = 0; i < _arrowList.Count; i++)
        {
            _arrowList[i].transform.position = new Vector3(_arrowPosition.x + (10 * i), 0, 0);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PoolManager.Instance.Push(_arrowList[_arrowCount]);
            _arrowCount++;
        }

        //CheckIndex();
    }

    private void CheckIndex()
    {
        if (_arrowList[0] == null)
        {
            _arrowCount = 0;
        }
    }
}
