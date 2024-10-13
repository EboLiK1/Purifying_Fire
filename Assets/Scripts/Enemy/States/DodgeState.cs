using UnityEngine;

public class DodgeState : EnemyState
{
    protected DodgeStateData StateData;

    protected bool IsPlayerInCloseRangeAction;
    protected bool IsPlayerInMaxAgroRange;
    protected bool IsPlayerInMinAgroRange;
    protected bool IsGrounded;
    protected bool IsDodgeOver;

    public DodgeState(EnemyStateMachine enemyStateMachine, Enemy enemy, DodgeStateData stateData) : base(enemyStateMachine, enemy)
    {
        StateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        IsDodgeOver = false;

        Vector2 targetDirection = Enemy.CurrentTarget.position - Enemy.transform.position;
        Vector2 rightDirection = Vector2.right;

        float dotProduct = Vector2.Dot(targetDirection, rightDirection);

        if(dotProduct < 0)
            Enemy.SetDodgeVelocity(StateData.DodgeSpeed);
        else
            Enemy.SetDodgeVelocity(-StateData.DodgeSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Time.time >= StartTime + StateData.DodgeTime)
        {
            Enemy.SetZeroVelocity();
            IsDodgeOver = true;
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        IsPlayerInCloseRangeAction = Enemy.IsPlayerInCloseRangeAction();
        IsPlayerInMaxAgroRange = Enemy.IsPlayerInMaxAgroRange();
    }
}
