public class PlayerDetectedState : EnemyState
{
    protected PlayerDetectedStateData StateData;

    protected bool IsPlayerInCloseRangeAction;
    protected bool IsPlayerInLongRangeAction;

    public PlayerDetectedState(EnemyStateMachine enemyStateMachine, Enemy enemy) : base(enemyStateMachine, enemy) { }

    public override void Enter()
    {
        base.Enter();

        Enemy.SetZeroVelocity();
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

        IsPlayerInCloseRangeAction = Enemy.IsPlayerInCloseRangeAction();
        IsPlayerInLongRangeAction = Enemy.IsPlayerInLongRangeAction();
    }
}