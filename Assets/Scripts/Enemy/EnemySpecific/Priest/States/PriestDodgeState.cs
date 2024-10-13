public class PriestDodgeState : DodgeState
{
    private Priest _priest;

    public PriestDodgeState(EnemyStateMachine enemyStateMachine, Priest priest, DodgeStateData stateData) : base(enemyStateMachine, priest, stateData)
    {
        _priest = priest;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        _priest.CanDodge = false;
        _priest.StartCoroutine(_priest.DodgeCooldownTimer());
    }

    public override void Update()
    {
        base.Update();

        if (IsDodgeOver)
        {
            if (IsPlayerInCloseRangeAction)
                EnemyStateMachine.SetState<PriestMeleeAttackState>();
            else
                EnemyStateMachine.SetState<PriestPlayerDetectedState>();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
