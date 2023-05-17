using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGaugeBar : MonoBehaviour
{
    [SerializeField]
    private float _maxHp = 50f;
    [SerializeField]
    private float _currentHp;

    [SerializeField]
    private Image _hpBar;

    private void Awake()
    {
        _currentHp = _maxHp;
        StartCoroutine(CalcHP());
    }

    private IEnumerator CalcHP()
    {
        while (_currentHp != 0)
        {
            _currentHp = Mathf.Lerp(_currentHp, 0, Time.deltaTime);
            _hpBar.fillAmount = _currentHp / _maxHp;
            Debug.Log(_hpBar.fillAmount);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
