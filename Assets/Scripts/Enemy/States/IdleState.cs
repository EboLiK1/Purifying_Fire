using UnityEngine;

public class IdleState : EnemyState
{
    protected IdleStateData StateData;

    protected float IdleTime;
    protected bool IsIdleTimeOver;
    protected bool IsPlayerDetected;

    public IdleState(EnemyStateMachine stateMachine, Enemy enemy, IdleStateData stateData) : base(stateMachine, enemy)
    {
        StateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        IdleTime = Random.Range(StateData.MinIdleTime, StateData.MaxIdleTime);
        IsIdleTimeOver = false;

        Enemy.SetZeroVelocity();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (Time.time >= StartTime + IdleTime)
            IsIdleTimeOver = true;
    }

    public override void FixedUpdate()
    {
        IsPlayerDetected = Enemy.IsPlayerDetected();
    }
}
