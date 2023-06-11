using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : PoolableMono
{
    private EnemyAnimator _animator;
    
    public override void Init()
    {
        _animator = transform.Find("Visual").GetComponent <EnemyAnimator>();
        PunchAnimationStart();
    }

    private void PunchAnimationStart()
    {
        _animator.PunchAnimation();
    }


}
