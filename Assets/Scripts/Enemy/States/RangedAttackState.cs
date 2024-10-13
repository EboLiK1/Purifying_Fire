using UnityEngine;

public class RangedAttackState : AttackState
{
    protected RangedAttackStateData StateData;

    protected GameObject Projectile;
    protected Projectile ProjectileScript;

    protected bool IsPlayerInMaxAgroRange;
    protected bool IsPlayerInMinAgroRange;

    public RangedAttackState(EnemyStateMachine enemyStateMachine, Enemy enemy, RangedAttackStateData stateData) : base(enemyStateMachine, enemy)
    {
        StateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();

        IsPlayerInMinAgroRange = Enemy.IsPlayerInMinAgroRange();
        IsPlayerInMaxAgroRange = Enemy.IsPlayerInMaxAgroRange();
    }
}