using UnityEngine;

public class SkeletonMovementState : MovementState
{
    private Skeleton _skeleton;

    public SkeletonMovementState(EnemyStateMachine enemyStateMachine, Skeleton skeleton, MovementStateData stateData) :
        base(enemyStateMachine, skeleton, stateData) 
    {
        _skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        if (_skeleton.PreviousTarget == _skeleton.RightPoint)
            _skeleton.CurrentTarget = _skeleton.LeftPoint;
        else
            _skeleton.CurrentTarget = _skeleton.RightPoint;

        _skeleton.Animator.SetBool("IsMovement", true);
    }

    public override void Exit()
    {
        _skeleton.Animator.SetBool("IsMovement", false);
    }

    public override void Update()
    {
        if (Vector3.Distance(_skeleton.transform.position, _skeleton.CurrentTarget.position) <= 1f)
        {
            if (_skeleton.CurrentTarget == _skeleton.LeftPoint)
            {
                _skeleton.CurrentTarget = _skeleton.RightPoint;
                _skeleton.PreviousTarget = _skeleton.LeftPoint;
                EnemyStateMachine.SetState<SkeletonIdleState>();
            }
            else if (_skeleton.CurrentTarget == _skeleton.RightPoint)
            {
                _skeleton.CurrentTarget = _skeleton.LeftPoint;
                _skeleton.PreviousTarget = _skeleton.RightPoint;
                EnemyStateMachine.SetState<SkeletonIdleState>();
            }
        }
        else
            _skeleton.MoveTowardsTarget(StateData.MoveSpeed);

        if(IsPlayerDetected)
            EnemyStateMachine.SetState<SkeletonChargeState>();
        if (!IsOnLedge)
            EnemyStateMachine.SetState<SkeletonIdleState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
