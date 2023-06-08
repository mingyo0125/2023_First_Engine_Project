using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public static ArrowSpawner Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("ArrowSpawner가 두개지요");
        }
        Instance = this;
    }

    [SerializeField]
    private int _arrowNum = 5;

    public List<Arrow> _arrowList = new List<Arrow>();
    [SerializeField]
    private Transform _arrowPosition;

    [SerializeField]
    private int roundCount = 0;
    private bool isCreating;

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
            Arrow arrow = PoolManager.Instance.Pop("Arrow") as Arrow;

            arrow.transform.position = new Vector3(_arrowPosition.transform.position.x + 1.3f * i, _arrowPosition.transform.position.y, _arrowPosition.transform.position.z);
            _arrowList.Add(arrow);

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

}
