using UnityEngine;

public class PriestMeleeAttackState : MeleeAttackState
{
    private Priest _priest;

    public PriestMeleeAttackState(EnemyStateMachine stateMachine, Priest priest, MeleeAttackStateData stateData) : base(stateMachine, priest, stateData)
    {
        _priest = priest;
    }

    public override void Enter()
    {
        base.Enter();

        _priest.Animator.SetBool("IsAttacking", true);
    }

    public override void Exit()
    {
        base.Exit();

        _priest.Animator.SetBool("IsAttacking", false);
        IsAttackAnimationFinished = true;
    }

    public override void Update()
    {
        base.Update();

        if (IsAttackAnimationFinished)
            EnemyStateMachine.SetState<PriestPlayerDetectedState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
