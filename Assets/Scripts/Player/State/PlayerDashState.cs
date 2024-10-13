using UnityEngine;

public class PlayerDashState : PlayerMovementState
{
    private float _dashTimer;

    private Vector2 _targetVelocity;
    private float _lastAfrerImagePosition;

    public PlayerDashState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        Player.Animator.SetBool("isDashing", true);
        _dashTimer = Player.PlayerData.DashDuration;
    }

    public override void Exit()
    {
        Player.Animator.SetBool("isDashing", false);
        Player.SetZeroVelocity();
        Player.CanDash = false;
        Player.StartCoroutine(Player.DashCooldownTimer());
    }

    public override void Update()
    {
        base.Update();

        #region Velocity - Вынести как-нибудь в отдельный метод
        if (Player.IsOnSlope())
            _targetVelocity = new Vector2(Player.PlayerData.DashSpeed * (Player.FaceRight ? -Player.SlopeNormalPerpendicular.x : Player.SlopeNormalPerpendicular.x),
                                          Player.PlayerData.DashSpeed * (Player.FaceRight ? -Player.SlopeNormalPerpendicular.y : Player.SlopeNormalPerpendicular.y));
        else
            _targetVelocity = new Vector2(Player.FaceRight ? Player.PlayerData.DashSpeed : -Player.PlayerData.DashSpeed,
                                          Player.Rigidbody.velocity.y);
        #endregion

        Move(_targetVelocity);

        UpdateDash();

        if (!Player.IsDashing)
        {
            if (Player.MoveDirection.x == 0f && Player.IsGrounded())
                PlayerStateMachine.SetState<PlayerIdleState>();
            else if (Player.MoveDirection.x != 0f && Player.IsGrounded())
                PlayerStateMachine.SetState<PlayerRunState>();
            else if (Player.IsFalling())
                PlayerStateMachine.SetState<PlayerFallState>();
        }
        else
        {
            CheckIfShouldPlaceAfterImage();
        }
    }

    private void UpdateDash()
    {
        _dashTimer -= Time.deltaTime;

        if (_dashTimer <= 0f)
            Player.IsDashing = false;
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        if (Mathf.Abs(Player.transform.position.x - _lastAfrerImagePosition) > Player.PlayerData.DistanceBetweenImage)
            PlaceAfterImage();
    }

    private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.CreateAfterImage();
        _lastAfrerImagePosition = Player.transform.position.x;
    }
}