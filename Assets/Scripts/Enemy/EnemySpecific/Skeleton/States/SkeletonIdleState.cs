using UnityEngine;

public class SkeletonIdleState : IdleState
{
    public SkeletonIdleState(EnemyStateMachine stateMachine, Skeleton skeleton, IdleStateData stateData) : base(stateMachine, skeleton, stateData) { }

    public override void Enter()
    {
        base.Enter();

        Enemy.Animator.SetBool("IsIdle", true);
    }

    public override void Exit()
    {
        Enemy.Animator.SetBool("IsIdle", false); ;
    }

    public override void Update()
    {
        base.Update();

        if (IsIdleTimeOver)
            EnemyStateMachine.SetState<SkeletonMovementState>();
        if(IsPlayerDetected)
            EnemyStateMachine.SetState<SkeletonChargeState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
