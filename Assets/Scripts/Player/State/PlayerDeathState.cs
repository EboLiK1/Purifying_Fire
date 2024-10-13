public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player)
    {
    }

    public override void Enter()
    {
        //Player.PlayerInput.Disable();

        Player.Animator.SetBool("isDead", true);
        Player.SetZeroVelocity();
        Game.Instance.GameOver();
    }
}
