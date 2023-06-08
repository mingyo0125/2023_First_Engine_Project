using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : PoolableMono
{
    Animator _animator;
    [SerializeField]
    List<AnimatorController> _animatorControllerList = new List<AnimatorController>();
    private readonly int hashAttack = Animator.StringToHash("AttackTrigger");
    
    public override void Init()
    {
        _animator = transform.Find("Visual").GetComponent<Animator>();
        int rand = Random.Range(0, _animatorControllerList.Count);
        _animator.runtimeAnimatorController = _animatorControllerList[rand];
        StartCoroutine(PunchAnimation());
    }

    private IEnumerator PunchAnimation()
    {
        _animator.SetTrigger(hashAttack);
        yield return new WaitForSeconds(0.5f);
    }
}
