using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAni : MonoBehaviour
{
    RectTransform _rectTransform;
    Canvas _canvas;
    CanvasScaler _canvasScaler;

    private IEnumerator Start()
    {

        yield return new WaitForSeconds(.5f);
        DotAniOn();
    }

    private void Awake()
    {

        _canvas = transform.parent.GetComponent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        
    }

    private void DotAniOn()
    {
        _rectTransform.DOMoveX(_canvas.transform.GetComponent<RectTransform>().rect.width/7, 1f).SetEase(Ease.OutBack);
    }

    public void DotAniOff()
    {
        _rectTransform.DOMoveX(-120f, 1f).SetEase(Ease.OutBack);
    }
}
