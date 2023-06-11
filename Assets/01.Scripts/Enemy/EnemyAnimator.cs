using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;
    
    private Animator _animator;
    public Animator Animator => _animator;

    [SerializeField]
    List<AnimatorController> _animatorControllerList = new List<AnimatorController>();

    private readonly int hashAttack = Animator.StringToHash("AttackTrigger");
    private readonly int hashDie = Animator.StringToHash("IsDie");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        int rand = UnityEngine.Random.Range(0, _animatorControllerList.Count);
        _animator.runtimeAnimatorController = _animatorControllerList[rand];
    }

    public void PunchAnimation()
    {
        _animator.SetTrigger(hashAttack);
    }

    public void AnimationEnd()
    {
        StartIdle();
    }

    private void StartIdle()
    {
        StartCoroutine(HPManager.Instance.HpMinus());
    }

    public void DieAnimation()
    {
        _animator.SetBool(hashDie, true);
    }

    public void DieAnimationEnd()
    {
        EnemyPush();
    }

    private void EnemyPush()
    {
        StartCoroutine(EnemySpawner.Instance.EnemyKill());
    }
}
