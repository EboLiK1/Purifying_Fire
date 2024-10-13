using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected Vector2 NullVector = Vector2.zero;

    protected bool IsTouchingWall;
    protected bool IsTouchingLedge;
    protected bool IsGrounded;

    public PlayerInAirState (PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter() { }
    public override void Exit() { }

    public override void Update()
    {
        base.Update();

        MoveInAir();

        if (Player.IsAttacking)
            Player.IsAttacking = false;
        else if (Player.IsDashing && Player.CanDash)
            PlayerStateMachine.SetState<PlayerDashState>();
        //else if (IsTouchingWall && !IsTouchingLedge && !IsGrounded)
        //    PlayerStateMachine.SetState<PlayerLedgeClimbState>();
    }

    public override void FixedUpdate() 
    {
        IsTouchingLedge = Player.IsTouchingLedge();
        IsTouchingWall = Player.IsTouchingWall();
        IsGrounded = Player.IsGrounded();

        //if (IsTouchingWall && !IsTouchingLedge)
        //    Player.SetDetectedPosition(Player.transform.position);
    }

    protected void MoveInAir()
    {
        Player.TargetVelocity = new Vector2(Player.MoveDirection.x * Player.PlayerData.MoveSpeed, Player.Rigidbody.velocity.y);

        Player.Rigidbody.velocity = Vector2.SmoothDamp(Player.Rigidbody.velocity, Player.TargetVelocity, ref NullVector, Player.PlayerData.SmoothTime);

        bool isWalking = Player.MoveDirection.x != 0f;

        if (isWalking && Mathf.Sign(Player.MoveDirection.x) != Mathf.Sign(Player.transform.localScale.x))
            Flip();
    }

    protected void Flip()
    {
        Player.FaceRight = !Player.FaceRight;

        Vector3 theScale = Player.transform.localScale;
        theScale.x *= -1;
        Player.transform.localScale = theScale;
    }
}
