using UnityEngine;

public class BossRunState : BossState
{
    private BossData _bossData;
    private Animator _animator;
    private Transform _target;

    public BossRunState(BossStateMachine bossStateMachine, Boss boss, BossData data, Animator animator, Transform target) :
        base(bossStateMachine, boss)
    {
        _bossData = data;
        _animator = animator;
        _target = target;
    }

    public override void Enter()
    {
        base.Enter();

        _animator.SetBool("isRun", true);
    }

    public override void Exit()
    {
        base.Exit();

        _animator.SetBool("isRun", false);
    }
    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Move();

        if (Boss.CanTakeLongAttack)
        {
            if (Boss.CurrentStage == BossStage.Stage2)
            {
                System.Random random = new System.Random();
                int randomChance = random.Next(1, 101);

                if (20f >= randomChance)
                {
                    if (Mathf.Abs(Boss.transform.position.x - _target.position.x) <= _bossData.LongAttackRange)
                        BossStateMachine.SetState<BossLongAttackState>();
                }
            }
        }
        

        if (Mathf.Abs(Boss.transform.position.x - _target.position.x) <= _bossData.AttackRange)
            BossStateMachine.SetState<BossAttackState>();
    }

    private void Move()
    {
        Vector3 direction = (_target.position - Boss.transform.position).normalized;
        direction.y = 0f;

        Vector3 newPosition = Boss.transform.position + direction * _bossData.RunSpeed * Time.fixedDeltaTime;

        Boss.transform.position = newPosition;

        if (direction.x != 0f && Mathf.Sign(direction.x) != Mathf.Sign(Boss.transform.localScale.x))
            Boss.Flip();
    }
}