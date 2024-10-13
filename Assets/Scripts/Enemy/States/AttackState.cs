using UnityEngine;

public class AttackState : EnemyState
{
    protected bool IsAttackAnimationFinished;

    public AttackState(EnemyStateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Enemy.AnimationToFSM.AttackState = this;
        IsAttackAnimationFinished = false;
        Enemy.SetZeroVelocity();
    }

    public override void Exit() { }

    public override void Update() { }

    public override void FixedUpdate() { }

    public virtual void TriggerAttack() { }

    public virtual void FinishAttack() => IsAttackAnimationFinished = true;
}
