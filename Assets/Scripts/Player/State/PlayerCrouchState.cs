using UnityEngine;

public class PlayerCrouchState : PlayerMovementState
{
    public PlayerCrouchState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        Player.Animator.SetBool("Squat", true);
        Player.StandCollider.enabled = false;
        Player.CrouchCollider.enabled = true;
    }

    public override void Exit()
    {
        Player.Animator.SetBool("Squat", false);
        Player.StandCollider.enabled = true;
        Player.CrouchCollider.enabled = false;
    }

    public override void Update()
    {
        base.Update();

        #region Velocity - Вынести как-нибудь в отдельный метод
        if (Player.IsOnSlope())
            TargetVelocity = new Vector2(-Player.MoveDirection.x * Player.PlayerData.CrouchSpeed * Player.SlopeNormalPerpendicular.x,
                                          -Player.MoveDirection.x * Player.PlayerData.CrouchSpeed * Player.SlopeNormalPerpendicular.y);
        else
            TargetVelocity = new Vector2(Player.MoveDirection.x * Player.PlayerData.CrouchSpeed,
                                         Player.Rigidbody.velocity.y);
        #endregion

        Move(TargetVelocity);

        if (!Player.IsCrouching && !Player.IsCeilingAbove())
        {
            if (Player.MoveDirection.x == 0f)
                PlayerStateMachine.SetState<PlayerIdleState>();
            else if (Player.MoveDirection.x != 0f)
                PlayerStateMachine.SetState<PlayerRunState>();
        }
        if (Player.IsDashing)
            Player.IsDashing = false;
        if (Player.IsAttacking)
            Player.IsAttacking = false;
    }
}