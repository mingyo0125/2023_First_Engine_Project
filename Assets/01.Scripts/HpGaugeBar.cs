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
        StartCoroutine(DecreseHP());
    }

    private void Update()
    {
        if( _currentHp <= 0)
        {
            GameOver?.Invoke();
        }
    }

    private IEnumerator DecreseHP()
    {
        while (_currentHp != 0)
        {
            _currentHp -= _roundCnt * 0.05f;
            _currentHp = Mathf.Clamp(_currentHp, 0, _maxHp);
            _hpBar.fillAmount = _currentHp / _maxHp;
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    public void HpMinus()
    {
        _currentHp -= _roundCnt * _minusValue;
    }

    public void HpReset()
    {
        _currentHp = _maxHp;
        _roundCnt++;
    }
}
