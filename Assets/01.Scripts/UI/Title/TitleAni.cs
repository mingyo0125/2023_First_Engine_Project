using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAni : MonoBehaviour
{
    RectTransform _rectTransform;

    private void Start()
    {
        DotAniOn();
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void DotAniOn()
    {
        _rectTransform.DOMoveX(120f, 1f).SetEase(Ease.OutBack);
    }

    public void DotAniOff()
    {
        _rectTransform.DOMoveX(-120f, 1f).SetEase(Ease.OutBack);
    }
}
