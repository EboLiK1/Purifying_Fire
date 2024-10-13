public class LookForPlayerState : EnemyState
{
    protected bool IsPlayerInCloseRangeAction;
    protected bool IsPlayerInLongRangeAction;

    public LookForPlayerState(EnemyStateMachine enemyStateMachine, Enemy enemy) : base(enemyStateMachine, enemy) { }

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

        IsPlayerInCloseRangeAction = Enemy.IsPlayerInCloseRangeAction();
    }
}