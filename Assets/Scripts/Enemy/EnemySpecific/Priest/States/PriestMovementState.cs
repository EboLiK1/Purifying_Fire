using UnityEngine;

public class PriestMovementState : MovementState
{
    private Priest _priest;

    public PriestMovementState(EnemyStateMachine enemyStateMachine, Priest priest, MovementStateData stateData) : base(enemyStateMachine, priest, stateData)
    {
        _priest = priest;
    }

    public override void Enter()
    {
        base.Enter();

        if (_priest.PreviousTarget == _priest.RightPoint)
            _priest.CurrentTarget = _priest.LeftPoint;
        else
            _priest.CurrentTarget = _priest.RightPoint;

        _priest.Animator.SetBool("IsMovement", true);
    }

    public override void Exit()
    {
        base.Exit();

        _priest.Animator.SetBool("IsMovement", false);
    }

    public override void Update()
    {
        base.Update();

        if (Vector3.Distance(_priest.transform.position, _priest.CurrentTarget.position) <= 1f)
        {
            if (_priest.CurrentTarget == _priest.LeftPoint)
            {
                _priest.CurrentTarget = _priest.RightPoint;
                _priest.PreviousTarget = _priest.LeftPoint;
                EnemyStateMachine.SetState<PriestIdleState>();
            }
            else if (_priest.CurrentTarget == _priest.RightPoint)
            {
                _priest.CurrentTarget = _priest.LeftPoint;
                _priest.PreviousTarget = _priest.RightPoint;
                EnemyStateMachine.SetState<PriestIdleState>();
            }
        }
        else
            _priest.MoveTowardsTarget(StateData.MoveSpeed);

        if (!IsOnLedge)
            EnemyStateMachine.SetState<PriestIdleState>();
        if(IsPlayerDetected)
            EnemyStateMachine.SetState<PriestPlayerDetectedState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
