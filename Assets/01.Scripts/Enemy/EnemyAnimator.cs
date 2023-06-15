using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;
    
    private Animator _animator;
    public Animator Animator => _animator;

    [SerializeField]
    private List<AnimatorController> _animatorControllerList = new List<AnimatorController>();

    private readonly int hashAttack = Animator.StringToHash("AttackTrigger");
    private readonly int hashDie = Animator.StringToHash("IsDie");

    private bool isAnimatingDie = false;
    public bool IsAnimatingDie => isAnimatingDie;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        int rand = UnityEngine.Random.Range(0, _animatorControllerList.Count);
        _animator.runtimeAnimatorController = _animatorControllerList[rand];
    }

    public void PlayPunchAnimation()
    {
        _animator.SetTrigger(hashAttack);
    }

    public void PlayDieAnimation()
    {
        isAnimatingDie = true;
        _animator.SetBool(hashDie, true);
    }

    public void OnDieAnimationComplete()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // Notify the enemy spawner that the die animation is complete
        EnemySpawner.Instance.OnEnemyDieAnimationComplete();
=======
=======
>>>>>>> parent of 717cd9e (바꾸기전)
        EnemySpawner.Instance.EnemyKill();
>>>>>>> parent of 717cd9e (바꾸기전)
    }
}
