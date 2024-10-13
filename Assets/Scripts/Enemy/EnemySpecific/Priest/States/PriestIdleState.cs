public class PriestIdleState : IdleState
{
    private Priest _priest;

    public PriestIdleState(EnemyStateMachine enemyStateMachine, Priest priest, IdleStateData stateData) : base(enemyStateMachine, priest, stateData)
    {
        _priest = priest;
    }

    public override void Enter()
    {
        base.Enter();

        _priest.Animator.SetBool("IsIdle", true);
    }

    public override void Exit()
    {
        base.Exit();

        _priest.Animator.SetBool("IsIdle", false);
    }

    public override void Update()
    {
        base.Update();

        if (IsIdleTimeOver)
            EnemyStateMachine.SetState<PriestMovementState>();
        if (IsPlayerDetected)
            EnemyStateMachine.SetState<PriestPlayerDetectedState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
