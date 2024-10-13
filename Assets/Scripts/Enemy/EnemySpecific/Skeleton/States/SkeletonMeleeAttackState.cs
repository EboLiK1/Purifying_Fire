using UnityEngine;

public class SkeletonMeleeAttackState : MeleeAttackState
{
    private Skeleton _skeleton;

    public SkeletonMeleeAttackState(EnemyStateMachine stateMachine, Skeleton skeleton, MeleeAttackStateData stateData) : base(stateMachine, skeleton, stateData)
    {
        _skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        _skeleton.Animator.SetBool("IsAttacking", true);
    }

    public override void Exit()
    {
        base.Exit();

        _skeleton.Animator.SetBool("IsAttacking", false);
        IsAttackAnimationFinished = true;
    }

    public override void Update()
    {
        base.Update();

        if (IsAttackAnimationFinished)
            EnemyStateMachine.SetState<SkeletonPlayerDetectedState>();
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
