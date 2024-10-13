public class PlayerAttackState : PlayerState
{
    private Weapon _weapon;

    public PlayerAttackState(PlayerStateMachine playerStateMachine, Player player, Weapon weapon) : base(playerStateMachine, player)
    {
        _weapon = weapon;

        _weapon.OnExit += ExitHandler;
    }

    public override void Enter()
    {
        IsAnimationFinished = false;
        Player.Animator.SetBool("isAttacking", true);
        Player.SetZeroVelocity();
        _weapon.Enter();
    }

    public override void Exit()
    {
        Player.Animator.SetBool("isAttacking", false);

        Player.IsAttacking = false;
    }

    public override void Update()
    {
        base.Update();

        if (IsAnimationFinished)
        {
            if (Player.MoveDirection.x == 0f)
                PlayerStateMachine.SetState<PlayerIdleState>();
            else if(Player.MoveDirection.x != 0f)
                PlayerStateMachine.SetState<PlayerRunState>();
        }
    }

    private void ExitHandler()
    {
        FinishAnimationTrigger();
    }
}