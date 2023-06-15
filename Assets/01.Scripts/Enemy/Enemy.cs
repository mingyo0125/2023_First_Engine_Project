public class Enemy : PoolableMono
{
    private EnemyAnimator _animator;

    public override void Init()
    {
        _animator = transform.Find("Visual").GetComponent<EnemyAnimator>();
        PlayPunchAnimation();
    }

    private void PlayPunchAnimation()
    {
        _animator.PlayPunchAnimation();
    }

    public void PlayDieAnimation()
    {
        _animator.PlayDieAnimation();
    }
}
