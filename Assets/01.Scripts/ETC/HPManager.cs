using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField]
    private float _maxHp = 100f;
    [SerializeField]
    private float _currentHp;

    [SerializeField]
    private Image _hpBar;

    private void Awake()
    {
        FillHp();
        StartCoroutine(HpMinus());
    }

    private void Update()
    {
        if( _currentHp <= 0)
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

    public IEnumerator HpMinus()
    {
        while (true)
        {
            if(ArrowSpawner.Instance.IsCreating == false)
            {
                Debug.Log("321312");
                _currentHp -= ArrowSpawner.Instance.RoundCount;
                _hpBar.fillAmount = _currentHp / _maxHp;
            }
            yield return new WaitForSeconds(0.1f);
            
        }
    }

    public void FillHp()
    {
        _currentHp = _maxHp;
    }


}
