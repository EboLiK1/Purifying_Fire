using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private Transform _jumpPoint;
    public PlayerIdleState(PlayerStateMachine playerStateMachine, Player player, Transform jumpPoint) : base(playerStateMachine, player) 
    {
        _jumpPoint = jumpPoint;
    }
    
    public override void Enter()
    {
        Player.Rigidbody.sharedMaterial = Player.FullFriction;

        if (PlayerStateMachine.GetPreviousState() is PlayerFallState)
        {
            GameObject jumpEffect = GameObject.Instantiate(Player.LandEffect, _jumpPoint.position, Quaternion.identity);
            jumpEffect.GetComponent<Animator>().SetTrigger("Land");
        }
    }

    public override void Exit()
    {
        Player.Rigidbody.sharedMaterial = Player.NoFriction;
    }

    public override void Update()
    {
        base.Update();

        if (Player.MoveDirection.x != 0f)
            PlayerStateMachine.SetState<PlayerRunState>();
        else if (Player.IsJumping)
            PlayerStateMachine.SetState<PlayerJumpState>();
        else if (Player.IsCrouching)
            PlayerStateMachine.SetState<PlayerCrouchState>();
        else if (Player.IsDashing && Player.CanDash)
            PlayerStateMachine.SetState<PlayerDashState>();
        else if (Player.IsAttacking)
            PlayerStateMachine.SetState<PlayerAttackState>();
        else if (Player.IsFalling())
            PlayerStateMachine.SetState<PlayerFallState>();
        
    }
}