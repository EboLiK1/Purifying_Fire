public class Skeleton : Enemy
{
    public IdleStateData IdleStateData;
    public MovementStateData MovementStateData;
    public ChargeStateData ChargeStateData;
    public MeleeAttackStateData MeleeAttackStateData;
    public DeadStateData DeadStateData;

    private EnemyHealth _enemyHealth;

    public override void Start()
    {
        base.Start();

        EnemyStateMachine.AddState(new SkeletonMovementState(EnemyStateMachine, this, MovementStateData));
        EnemyStateMachine.AddState(new SkeletonIdleState(EnemyStateMachine, this, IdleStateData));
        EnemyStateMachine.AddState(new SkeletonChargeState(EnemyStateMachine, this, ChargeStateData));
        EnemyStateMachine.AddState(new SkeletonMeleeAttackState(EnemyStateMachine, this, MeleeAttackStateData));
        EnemyStateMachine.AddState(new SkeletonDeadState(EnemyStateMachine, this));
        EnemyStateMachine.AddState(new SkeletonGetDamageState(EnemyStateMachine, this));
        EnemyStateMachine.AddState(new SkeletonPlayerDetectedState(EnemyStateMachine, this));

        EnemyStateMachine.SetState<SkeletonIdleState>();

        _enemyHealth = GetComponent<EnemyHealth>();

        _enemyHealth.OnGetDamage += SetGetDamageState;
        _enemyHealth.OnDead += EnemyDead;

        CurrentTarget = LeftPoint;
        PreviousTarget = RightPoint;
    }

    private void SetGetDamageState() => 
        EnemyStateMachine.SetState<SkeletonGetDamageState>();

    private void EnemyDead() =>
        EnemyStateMachine.SetState<SkeletonDeadState>();
}
