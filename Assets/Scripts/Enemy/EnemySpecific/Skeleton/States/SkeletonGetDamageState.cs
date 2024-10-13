public class SkeletonGetDamageState : GetDamageState
{
    Skeleton _skeleton;

    public SkeletonGetDamageState(EnemyStateMachine stateMachine, Skeleton skeleton) : base(stateMachine, skeleton)
    {
        _skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.CurrentTarget = Enemy.PlayerZapasnoy;
        Enemy.FlipTowardsPlayer();
        _skeleton.Animator.SetTrigger("GetDamage");
    }

    public override void Update()
    {
        base.Update();

        if (IsGetDamageAnimationFinished)
            EnemyStateMachine.SetState<SkeletonPlayerDetectedState>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}