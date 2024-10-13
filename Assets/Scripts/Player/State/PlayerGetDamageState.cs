public class PlayerGetDamageState : PlayerState
{
    public PlayerGetDamageState(PlayerStateMachine playerStateMachine, Player player) : base(playerStateMachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.AnimationToFSM.PlayerGetDamageState = this;
        IsAnimationFinished = false;
        Player.Animator.SetTrigger("GetDamage");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAnimationTrigger()
    {
        base.FinishAnimationTrigger();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();

        if (IsAnimationFinished)
        {
            if (Player.MoveDirection.x != 0f)
                PlayerStateMachine.SetState<PlayerRunState>();
            else
                PlayerStateMachine.SetState<PlayerIdleState>();
        }

    }
}