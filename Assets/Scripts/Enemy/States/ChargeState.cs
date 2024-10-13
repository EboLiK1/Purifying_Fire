using UnityEngine;

public class ChargeState : EnemyState
{
    protected ChargeStateData StateData;

    protected bool IsOnLedge;
    protected bool PerformCloseRangeAction;

    public ChargeState(EnemyStateMachine stateMachine, Enemy enemy, ChargeStateData stateData) : base(stateMachine, enemy)
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
        Enemy.MoveTowardsTarget(StateData.ChargeSpeed);
    }

    public override void FixedUpdate()
    {
        IsOnLedge = Enemy.IsOnLedge();
        PerformCloseRangeAction = Enemy.IsPlayerInCloseRangeAction();
    }
}
