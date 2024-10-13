public abstract class PlayerState
{
    protected readonly PlayerStateMachine PlayerStateMachine;
    protected readonly Player Player;

    protected bool IsAnimationFinished;

    public PlayerState(PlayerStateMachine playerStateMachine, Player player)
    {
        PlayerStateMachine = playerStateMachine;
        Player = player;
    }

    public virtual void Enter() 
    {

    }
    public virtual void Update() 
    {
        if(Player.IsDashing && !Player.CanDash)
            Player.IsDashing = false;
    }

    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void StartAnimationTrigger() { }
    public virtual void FinishAnimationTrigger() =>
        IsAnimationFinished = true;
}