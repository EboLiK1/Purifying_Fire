public class PriestGetDamageState : GetDamageState
{
    private Priest _priest;

    public PriestGetDamageState(EnemyStateMachine stateMachine, Priest priest) : base(stateMachine, priest)
    {
        _priest = priest;
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.CurrentTarget = Enemy.PlayerZapasnoy;
        Enemy.FlipTowardsPlayer();
        _priest.Animator.SetTrigger("GetDamage");
    }

    public override void Update()
    {
        base.Update();

        if (IsGetDamageAnimationFinished)
            EnemyStateMachine.SetState<PriestPlayerDetectedState>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}