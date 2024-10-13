public class SkeletonDeadState : DeadState
{
    private Skeleton _skeleton;

    public SkeletonDeadState(EnemyStateMachine stateMachine, Skeleton skeleton) : base(stateMachine, skeleton)
    {
        _skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
