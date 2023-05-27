using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpGaugeBar : MonoBehaviour
{
    public UnityEvent GameOver;

    [SerializeField]
    private float _maxHp = 50f;
    [SerializeField]
    private float _currentHp;
    [SerializeField]
    private float _minusValue;
    [SerializeField]
    private float _roundCnt = 0;

    [SerializeField]
    private Image _hpBar;

    private void Awake()
    {
        _currentHp = _maxHp;
    }

    private void Update()
    {
        if( _currentHp <= 0)
        {
            GameOver?.Invoke();
        }
    }

    public void HpMinus()
    {
        _currentHp -= _roundCnt * _minusValue;
        _hpBar.fillAmount = _currentHp / _maxHp;
    }

}
