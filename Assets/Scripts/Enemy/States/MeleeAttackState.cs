using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected MeleeAttackStateData StateData;

    public MeleeAttackState(EnemyStateMachine stateMachine, Enemy enemy, MeleeAttackStateData stateData) : 
        base(stateMachine, enemy)
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

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Enemy.EnemyMeleeCombat.Damage(StateData.DamageAmount);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
