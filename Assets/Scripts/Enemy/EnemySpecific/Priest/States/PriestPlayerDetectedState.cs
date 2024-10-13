using UnityEngine;

public class PriestPlayerDetectedState : PlayerDetectedState
{
    private Priest _priest;

    public PriestPlayerDetectedState(EnemyStateMachine enemyStateMachine, Priest priest) : base(enemyStateMachine, priest)
    {
        _priest = priest;
    }

    public override void Enter()
    {
        base.Enter();

        _priest.Animator.SetBool("IsPlayerDetected", true);
    }

    public override void Exit()
    {
        base.Exit();

        _priest.Animator.SetBool("IsPlayerDetected", false);
    }

    public override void Update()
    {
        base.Update();

        Enemy.FlipTowardsPlayer();

        if (IsPlayerInCloseRangeAction)
        {
            if (_priest.CanDodge)
                EnemyStateMachine.SetState<PriestDodgeState>();
            else
                EnemyStateMachine.SetState<PriestMeleeAttackState>();
        }
        else if (IsPlayerInLongRangeAction)
            EnemyStateMachine.SetState<PriestRangedAttackState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}