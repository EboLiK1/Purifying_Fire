public class GetDamageState : EnemyState
{
    protected bool IsGetDamageAnimationFinished;

    public GetDamageState(EnemyStateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.AnimationToFSM.GetDamageState = this;
        IsGetDamageAnimationFinished = false;
    }

    public override void Exit() { }

    public override void Update() { }

    public override void FixedUpdate() { }

    public virtual void TriggerAttack() { }

    public virtual void FinishAttack() => IsGetDamageAnimationFinished = true;
}
