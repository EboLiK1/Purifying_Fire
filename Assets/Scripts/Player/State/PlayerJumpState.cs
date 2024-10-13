using UnityEngine;

public class PlayerJumpState : PlayerInAirState
{
    private Transform _jumpPoint;
    public PlayerJumpState(PlayerStateMachine playerStateMachine, Player player, Transform jumpPoint) : base(playerStateMachine, player) 
    {
        _jumpPoint = jumpPoint;
    }

    public override void Enter()
    {
        GameObject jumpEffect = GameObject.Instantiate(Player.JumpEffect, _jumpPoint.position, Quaternion.identity);
        jumpEffect.GetComponent<Animator>().SetTrigger("Jump");
        Player.Animator.SetBool("isJumping", true);
        Jump();
    }

    public override void Exit()
    {
        Player.Animator.SetBool("isJumping", false);
    }

    public override void Update()
    {
        base.Update();

        if (Player.IsFalling())
            PlayerStateMachine.SetState<PlayerFallState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Jump()
    {
        Player.Rigidbody.velocity = new Vector2(Player.Rigidbody.velocity.x, Player.PlayerData.JumpForce);
    }

}