using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleArrow : MonoBehaviour
{
    [SerializeField]
    List<Image> visibleArrowList = new List<Image>();

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
        for (int i = 0; i < visibleArrowList.Count; i++)
        {
            visibleArrowList[i].enabled = true;

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

            Vector3 rotateVec = visibleArrowList[i].rectTransform.eulerAngles;
            rotateVec.z = value;
            visibleArrowList[i].rectTransform.eulerAngles = rotateVec;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
