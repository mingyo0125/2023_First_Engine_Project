public class Enemy : PoolableMono
{
    private EnemyAnimator _animator;

    public override void Init()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        _animator = transform.Find("Visual").GetComponent<EnemyAnimator>();
        PlayPunchAnimation();
=======
=======
>>>>>>> parent of 717cd9e (바꾸기전)
        _animator = transform.Find("Visual").GetComponent <EnemyAnimator>();
        PunchAnimationStart();
>>>>>>> parent of 717cd9e (바꾸기전)
    }

    private void PlayPunchAnimation()
    {
        _animator.PlayPunchAnimation();
    }

    public void PlayDieAnimation()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        _animator.PlayDieAnimation();
=======
=======
>>>>>>> parent of 717cd9e (바꾸기전)
        _animator.DieAnimation();
>>>>>>> parent of 717cd9e (바꾸기전)
    }
}
