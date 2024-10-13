using UnityEngine;

public class PlayerMovementState : PlayerState
{
    protected Vector2 NullVector = Vector2.zero;
    protected Vector2 TargetVelocity;

    //protected Vector2 SlopeNormalPerpendicular;
    //protected float SlopeDownAngle;

    public PlayerMovementState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        base.Update();

        Player.Animator.SetFloat("MoveX", Mathf.Abs(Player.MoveDirection.x));
    }

    public virtual void Move(Vector2 targetVelocity)
    {
        Player.TargetVelocity = targetVelocity;
        Player.Rigidbody.velocity = Vector2.SmoothDamp(Player.Rigidbody.velocity, Player.TargetVelocity, ref NullVector, Player.PlayerData.SmoothTime);

        bool isWalking = Player.MoveDirection.x != 0f;

        if (isWalking && Mathf.Sign(Player.MoveDirection.x) != Mathf.Sign(Player.transform.localScale.x))
            Player.Flip();
    }
}
