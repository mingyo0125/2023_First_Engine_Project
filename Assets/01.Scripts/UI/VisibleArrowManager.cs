using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleArrowManager : MonoBehaviour
{
    public static VisibleArrowManager Instance;

    public List<Image> VisibleArrowList = new List<Image>();
    
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
            VisibleArrowList[i].enabled = true;

            KeyCode keyCode = ArrowSpawner.Instance._arrowList[i].keyCode;

            float value = 0;

            switch (keyCode)
            {
                case KeyCode.LeftArrow:
                    value = 180;
                    break;
                case KeyCode.RightArrow:
                    value = 0;
                    break;
                case KeyCode.UpArrow:
                    value = 90;
                    break;
                case KeyCode.DownArrow:
                    value = -90;
                    break;
            }

            Vector3 rotateVec = VisibleArrowList[i].rectTransform.eulerAngles;
            rotateVec.z = value;
            VisibleArrowList[i].rectTransform.eulerAngles = rotateVec;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
