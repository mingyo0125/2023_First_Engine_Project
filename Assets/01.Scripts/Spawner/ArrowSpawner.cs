using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public static ArrowSpawner Instance;

    public int _arrowNum = 5;

    public List<Arrow> _arrowList = new List<Arrow>();
    [SerializeField]
    private Transform _arrowPosition;

    public int RoundCount = 1;
    public bool IsCreating;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ArrowSpawner가 두개지요");
        }
        Instance = this;
        
    }

    private void Start()
    {
        Succes();
    }

    private IEnumerator InitArrow()
    {
        IsCreating = true;
        _arrowList?.Clear();

        for (int i = 0; i < _arrowNum; i++)
        {
            Arrow arrow = PoolManager.Instance.Pop("Arrow") as Arrow;

            arrow.transform.position = new Vector3(_arrowPosition.transform.position.x + 2.5f * i, _arrowPosition.transform.position.y, _arrowPosition.transform.position.z);
            _arrowList.Add(arrow);

            yield return new WaitForSeconds(0.3f);
        }

        IsCreating = false;
        if (RoundCount == 5)
        {
            RoundCount = 1;
        }
    }


    public void Succes()
    {
        RoundCount++;

        StopAllCoroutines();
        StartCoroutine(InitArrow());
    }

}
