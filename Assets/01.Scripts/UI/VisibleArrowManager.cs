using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleArrowManager : MonoBehaviour
{
    public static VisibleArrowManager Instance;

    public List<VisiableArrow> VisibleArrowList = new List<VisiableArrow>();

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("VisibleArrowManager2°³");
        }
        Instance = this;
    }

    private void Start()
    {
        VisibleArrowInit();
    }

    public void VisibleArrowInit()
    {
        StartCoroutine(VisibleArrowCoroutine());
    }

    private IEnumerator VisibleArrowCoroutine()
    {
        for (int i = 0; i < VisibleArrowList.Count; i++)
        {
            VisibleArrowList[i].gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);
        }

    }
}
