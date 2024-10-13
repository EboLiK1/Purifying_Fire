using UnityEngine;

public class StunState : EnemyState
{
    protected StunStateData StateData;

    protected bool IsStunTimeOver;
    protected bool IsGrounded;
    protected bool IsMovementStopped;
    protected bool PerformCloseRangeAction;

    public StunState(EnemyStateMachine stateMachine, Enemy entity, StunStateData stateData) : base(stateMachine, entity)
    {
        StateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        IsStunTimeOver = false;
        IsMovementStopped = false;

        Enemy.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Time.time >= StartTime + StateData.StunTime)
            IsStunTimeOver = true;
        if (IsGrounded && Time.time >= StartTime + StateData.StunKnockbackTime && !IsMovementStopped)
        {
            IsMovementStopped = true;
            Enemy.SetZeroVelocity();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        IsGrounded = Enemy.IsGrounded();
        PerformCloseRangeAction = Enemy.IsPlayerInCloseRangeAction();
    }
}