public class PlayerFallState : PlayerInAirState
{
    public PlayerFallState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        Player.Animator.SetBool("isFalling", true);
    }

    public override void Exit()
    {
        Player.Animator.SetBool("isFalling", false);
    }

    public override void Update()
    {
        base.Update();

        if (!Player.IsFalling() && Player.MoveDirection.x == 0f)
            PlayerStateMachine.SetState<PlayerIdleState>();
        else if (!Player.IsFalling() && Player.MoveDirection.x != 0f)
            PlayerStateMachine.SetState<PlayerRunState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        IsTouchingWall = Player.IsTouchingWall();
    }
}