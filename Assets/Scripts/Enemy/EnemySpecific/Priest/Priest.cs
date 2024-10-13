using System.Collections;
using UnityEngine;

public class Priest : Enemy
{
    [SerializeField] private IdleStateData _idleStateData;
    [SerializeField] private MovementStateData _movementStateData;
    [SerializeField] private PlayerDetectedStateData _playerDetectedStateData;
    [SerializeField] private MeleeAttackStateData _meleeAttackStateData;
    [SerializeField] private DodgeStateData _dodgeStateData;
    [SerializeField] private RangedAttackStateData _rangedAttackStateData;

    [SerializeField] private Transform _rangeAttackPosition;

    private EnemyHealth _enemyHealth;

    private float _dodgeCooldown = 2f;
    public bool CanDodge;
    public bool CanAttack;

    public override void Start()
    {
        base.Start();

        EnemyStateMachine.AddState(new PriestIdleState(EnemyStateMachine, this, _idleStateData));
        EnemyStateMachine.AddState(new PriestMovementState(EnemyStateMachine, this, _movementStateData));
        EnemyStateMachine.AddState(new PriestPlayerDetectedState(EnemyStateMachine, this));
        EnemyStateMachine.AddState(new PriestMeleeAttackState(EnemyStateMachine, this, _meleeAttackStateData));
        EnemyStateMachine.AddState(new PriestDodgeState(EnemyStateMachine, this, _dodgeStateData));
        EnemyStateMachine.AddState(new PriestRangedAttackState(EnemyStateMachine, this, _rangedAttackStateData, _rangeAttackPosition));
        EnemyStateMachine.AddState(new PriestGetDamageState(EnemyStateMachine, this));
        EnemyStateMachine.AddState(new PriestDeadState(EnemyStateMachine, this));

        EnemyStateMachine.SetState<PriestIdleState>();

        _enemyHealth = GetComponent<EnemyHealth>();

        _enemyHealth.OnGetDamage += SetGetDamageState;
        _enemyHealth.OnDead += EnemyDead;

        CanDodge = true;
    }

    private void SetGetDamageState() =>
        EnemyStateMachine.SetState<PriestGetDamageState>();

    private void EnemyDead() =>
        EnemyStateMachine.SetState<PriestDeadState>();

    public IEnumerator DodgeCooldownTimer()
    {
        yield return new WaitForSeconds(_dodgeCooldown);

        CanDodge = true;
    }
}
