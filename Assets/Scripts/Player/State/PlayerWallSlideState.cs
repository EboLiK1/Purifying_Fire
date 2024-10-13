using UnityEngine;

internal class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        base.Enter();

        Player.Animator.SetBool("isWallSliding", true);
    }

    public override void Exit()
    {
        base.Exit();

        Player.Animator.SetBool("isWallSliding", false);
    }

    public override void Update()
    {
        base.Update();

        SlideOnWall();

        if (Player.IsJumping)
            PlayerStateMachine.SetState<PlayerJumpState>();

        //TODO : Я понял почему у меня при прыжке от стены персонаж не прыгает в сторону. Потому что я перехожу в Jump а у него есть метод Move, так получается что метод выполняется и я не двигаюсь
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void SlideOnWall() =>
        Player.Rigidbody.velocity = new Vector2(Player.Rigidbody.velocity.x, -Player.PlayerData.WallSlideSpeed);
}
