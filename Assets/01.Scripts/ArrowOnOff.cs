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
        for(int i = 0; i < 3; i++)
        {
            Arrow arrow = PoolManager.Instance.Pop("Test") as Arrow;
            _arrowList.Add(arrow);
            arrow.transform.position = new Vector3(_arrowPosition.x + (10 * i),0,0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PoolManager.Instance.Push(_arrowList[_arrowCount]);
            _arrowCount++;
        }
    }
}
