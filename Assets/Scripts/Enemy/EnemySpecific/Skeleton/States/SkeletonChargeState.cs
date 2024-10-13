using UnityEngine;

public class SkeletonChargeState : ChargeState
{
    private Skeleton _skeleton;

    public SkeletonChargeState(EnemyStateMachine stateMachine, Skeleton skeleton, ChargeStateData stateData) : base(stateMachine, skeleton, stateData)
    {
        _skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.Animator.SetBool("IsChargeing", true);
    }

    public override void Exit()
    {
        Enemy.Animator.SetBool("IsChargeing", false);
    }

    public override void Update()
    {
        base.Update();

        if (!IsOnLedge)
            EnemyStateMachine.SetState<SkeletonIdleState>();
        if(PerformCloseRangeAction)
            EnemyStateMachine.SetState<SkeletonMeleeAttackState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
