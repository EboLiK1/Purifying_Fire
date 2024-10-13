using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 _cornerPosition;
    private Vector2 _startPosition;
    private Vector2 _stopPosition;

    public PlayerLedgeClimbState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player) { }

    public override void Enter()
    {
        base.Enter();

        IsAnimationFinished = false;

        Player.SetZeroVelocity();
        Player.transform.position = Player.GetDetectedPosition();
        _cornerPosition = Player.DetermineCornerPosition();

        _startPosition.Set(_cornerPosition.x - ((Player.FaceRight ? 1 : -1) * Player.PlayerData.StartOffset.x), _cornerPosition.y - Player.PlayerData.StartOffset.y);
        _stopPosition.Set(_cornerPosition.x + ((Player.FaceRight ? 1 : -1) * Player.PlayerData.StopOffset.x), _cornerPosition.y + Player.PlayerData.StopOffset.y);

        Player.transform.position = _startPosition;

        Player.Animator.SetBool("IsClimbing", true);
    }

    public override void Exit()
    {
        base.Exit();

        Player.Animator.SetBool("IsClimbing", false);

        Player.transform.position = _stopPosition;
    }

    public override void Update()
    {
        base.Update();

        if (IsAnimationFinished)
            PlayerStateMachine.SetState<PlayerIdleState>();
        else
        {
            Player.SetZeroVelocity();
            Player.transform.position = _startPosition;
        }

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
