public class SkeletonPlayerDetectedState : PlayerDetectedState
{
    private Skeleton _skeleton;

    public SkeletonPlayerDetectedState(EnemyStateMachine enemyStateMachine, Skeleton skeleton) : base(enemyStateMachine, skeleton)
    {
        _skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        _skeleton.Animator.SetBool("IsPlayerDetected", true);
    }

    public override void Exit()
    {
        base.Exit();

        _skeleton.Animator.SetBool("IsPlayerDetected", false);
    }

    public override void Update()
    {
        base.Update();

        Enemy.FlipTowardsPlayer();

        if (IsPlayerInCloseRangeAction)
            EnemyStateMachine.SetState<SkeletonMeleeAttackState>();
        else if (IsPlayerInLongRangeAction)
            EnemyStateMachine.SetState<SkeletonChargeState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}