using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static HPManager Instance;

    [SerializeField]
    private float _maxHp = 100f;
    [SerializeField]
    private float _currentHp;

    [SerializeField]
    private Image _hpBar;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("에이치피매니저가두개예요");
        }
        Instance = this;
        FillHp();
    }

    private void Update()
    {
        if( _currentHp <= 0)
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

    private void Start()
    {
        StartCoroutine(HpMinus());
    }

    public IEnumerator HpMinus()
    {
        while (true)
        {
            if(ArrowSpawner.Instance.IsCreating == false)
            {
                _currentHp -= ArrowSpawner.Instance.RoundCount;
                _hpBar.fillAmount = _currentHp / _maxHp;
            }
            yield return new WaitForSeconds(0.1f);
            
        }
    }

    public void FillHp()
    {
        _currentHp = _maxHp + 10;
    }


}
