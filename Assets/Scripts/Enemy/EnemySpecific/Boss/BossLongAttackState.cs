using UnityEngine;

public class BossLongAttackState : BossState
{
    private BossData _bossData;
    private Animator _animator;
    private Transform _target;
    private Rigidbody2D _rigidbody;
    private BossAnimationToFSM _bossAnimationToFSM;

    private bool IsAttackFinished;

    public BossLongAttackState(BossStateMachine bossStateMachine, Boss boss, BossData data, Animator animator, Transform target, BossAnimationToFSM bossAnimationToFSM, Rigidbody2D rigidbody) :
        base(bossStateMachine, boss)
    {
        _bossData = data;
        _animator = animator;
        _target = target;
        _bossAnimationToFSM = bossAnimationToFSM;
        _rigidbody = rigidbody;
    }

    public override void Enter()
    {
        base.Enter();

        Vector2 targetDirection = _target.position - Boss.transform.position;
        Vector2 rightDirection = Vector2.right;

        float dotProduct = Vector2.Dot(targetDirection, rightDirection);

        if (dotProduct < 0)
            _rigidbody.velocity = new Vector2(-_bossData.DodgeSpeed, 0f);
        else
            _rigidbody.velocity = new Vector2(_bossData.DodgeSpeed, 0f);

        _animator.SetBool("isLongAttacking", true);
    }

    public override void Exit()
    {
        base.Exit();

        _animator.SetBool("isLongAttacking", false);
        Boss.CanTakeLongAttack = false;
        Boss.StartCoroutine(Boss.LongAttackCooldown());
    }

    public override void Update()
    {
        if (Time.time >= StartTime + _bossData.DodgeDuration)
        {
            Boss.SetZeroVelocity();
            BossStateMachine.SetState<BossRunState>();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void FinishAttack() => IsAttackFinished = true;
}