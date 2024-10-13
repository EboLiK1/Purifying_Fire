public class MovementState : EnemyState
{
    protected MovementStateData StateData;

    protected bool IsOnLedge;
    protected bool IsPlayerDetected;

    public MovementState(EnemyStateMachine enemyStateMachine, Enemy enemy, MovementStateData stateData) : base(enemyStateMachine, enemy)
    {
        StateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        IsOnLedge = Enemy.IsOnLedge();
        IsPlayerDetected = Enemy.IsPlayerDetected();
    }
}
