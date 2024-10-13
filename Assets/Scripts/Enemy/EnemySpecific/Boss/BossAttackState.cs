using UnityEngine;

public class BossAttackState : BossState
{
    private BossData _bossData;
    private Animator _animator;
    private Transform _target;
    private BossAnimationToFSM _bossAnimationToFSM;

    private bool IsAttackFinished;

    public BossAttackState(BossStateMachine bossStateMachine, Boss boss, BossData data, Animator animator, Transform target, BossAnimationToFSM bossAnimationToFSM) :
        base(bossStateMachine, boss)
    {
        _bossData = data;
        _animator = animator;
        _target = target;
        _bossAnimationToFSM = bossAnimationToFSM;
    }

    public override void Enter()
    {
        base.Enter();

        Boss.SetZeroVelocity();
        IsAttackFinished = false;
        _bossAnimationToFSM.BossAttackState = this;
        _animator.SetBool("isAttacking", true);
    }

    public override void Exit()
    {
        base.Exit();

        _animator.SetBool("isAttacking", false);
    }

    public override void Update()
    {
        if (IsAttackFinished)
        {
            if (Mathf.Abs(Boss.transform.position.x - _target.position.x) >= _bossData.AttackRange)
                BossStateMachine.SetState<BossRunState>();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void FinishAttack() => IsAttackFinished = true;
}