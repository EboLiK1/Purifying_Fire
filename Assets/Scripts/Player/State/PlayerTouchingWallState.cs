using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool IsGrounded;
    protected bool IsTouchingWall;

    public PlayerTouchingWallState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (IsGrounded)
            PlayerStateMachine.SetState<PlayerIdleState>();
        else if (!IsTouchingWall)
            PlayerStateMachine.SetState<PlayerFallState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        IsGrounded = Player.IsGrounded();
        IsTouchingWall = Player.IsTouchingWall();
    }
}
