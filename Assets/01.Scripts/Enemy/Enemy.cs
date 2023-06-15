public class Enemy : PoolableMono
{
    private EnemyAnimator _animator;

    public override void Init()
    {
<<<<<<< HEAD
        _animator = transform.Find("Visual").GetComponent<EnemyAnimator>();
        PlayPunchAnimation();
=======
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
        _animator.PlayDieAnimation();
=======
        _animator.DieAnimation();
>>>>>>> parent of 717cd9e (바꾸기전)
    }
}
