using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScope : MonoBehaviour
{
    Animator _animator;

    private readonly int hashScope = Animator.StringToHash("IsScope");
    private readonly int hashEnd = Animator.StringToHash("IsEnd");
    private readonly int hashShoot = Animator.StringToHash("ShootTrigger");

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        //ScopeOn();
    }

    public void ScopeOff()
    {
        _animator.SetBool(hashScope, false);
    }

    public void ScopeOn()
    {
        _animator.SetBool(hashEnd, false);
        _animator.SetBool(hashScope, true);
    }

    public void ScopeOffAniEnd()
    {
        _animator.SetBool(hashEnd, true);
    }

    public void Rebound()
    {
        _animator.SetTrigger(hashShoot);
    }

}
