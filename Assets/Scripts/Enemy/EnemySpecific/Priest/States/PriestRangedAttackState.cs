using UnityEngine;

public class PriestRangedAttackState : RangedAttackState
{
    private Priest _priest;

    private GameObject _object;
    private Projectile _projectile;
    private Transform _attackPosition;

    private bool _isPlayerInCloseRangeAction;

    public PriestRangedAttackState(EnemyStateMachine enemyStateMachine, Priest priest, RangedAttackStateData stateData, Transform attackPosition) : base(enemyStateMachine, priest, stateData)
    {
        _priest = priest;
        _attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();

        _priest.Animator.SetBool("IsAttackingRange", true);
    }

    public override void Exit()
    {
        base.Exit();

        _priest.Animator.SetBool("IsAttackingRange", false);
    }

    public override void Update()
    {
        base.Update();

        Enemy.FlipTowardsPlayer();

        if (_isPlayerInCloseRangeAction)
        {
            if (_priest.CanDodge)
                EnemyStateMachine.SetState<PriestDodgeState>();
            else
                EnemyStateMachine.SetState<PriestMeleeAttackState>();
        }

        if (IsAttackAnimationFinished)
            EnemyStateMachine.SetState<PriestPlayerDetectedState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        _isPlayerInCloseRangeAction = _priest.IsPlayerInCloseRangeAction();
    }
    
    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Vector2 direction = new Vector2(_priest.CurrentTarget.position.x - _attackPosition.position.x, _priest.CurrentTarget.position.y - _attackPosition.position.y).normalized;

        _object = GameObject.Instantiate(StateData.Projectile, _attackPosition.position, _attackPosition.rotation);
        _projectile = _object.GetComponent<Projectile>();
        _projectile.Init(direction, StateData.ProjectileSpeed);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}