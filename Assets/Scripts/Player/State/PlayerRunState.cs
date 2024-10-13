using UnityEngine;

public class PlayerRunState : PlayerMovementState
{
    private Vector2 _targetVelocity;

    public PlayerRunState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        Player.Rigidbody.sharedMaterial = Player.NoFriction;
    }

    public override void Exit()
    {
        Player.Animator.SetFloat("MoveX", 0f);
    }

    public override void Update()
    {
        base.Update();

        #region Velocity - Вынести как-нибудь в отдельный метод
        if (Player.IsOnSlope())
            _targetVelocity = new Vector2(-Player.MoveDirection.x * Player.PlayerData.MoveSpeed * Player.SlopeNormalPerpendicular.x,
                                          -Player.MoveDirection.x * Player.PlayerData.MoveSpeed * Player.SlopeNormalPerpendicular.y);
        else
            _targetVelocity = new Vector2(Player.MoveDirection.x * Player.PlayerData.MoveSpeed,
                                          Player.Rigidbody.velocity.y);
        #endregion

        Move(_targetVelocity);

        if (Player.MoveDirection.x == 0f)
            PlayerStateMachine.SetState<PlayerIdleState>();
        else if (Player.IsJumping)
            PlayerStateMachine.SetState<PlayerJumpState>();
        else if (Player.IsFalling())
            PlayerStateMachine.SetState<PlayerFallState>();
        else if (Player.IsCrouching)
            PlayerStateMachine.SetState<PlayerCrouchState>();
        else if(Player.IsDashing && Player.CanDash)
            PlayerStateMachine.SetState<PlayerDashState>();
        else if (Player.IsAttacking)
            PlayerStateMachine.SetState<PlayerAttackState>();
    }
}
