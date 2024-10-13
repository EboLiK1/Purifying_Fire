using UnityEngine;

public class BossDodgeState : BossState
{
    private BossData _bossData;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Transform _target;

    private bool _isDodgeOver;

    public BossDodgeState(BossStateMachine bossStateMachine, Boss boss, BossData data, Animator animator, Transform target, Rigidbody2D rigidbody) :
        base(bossStateMachine, boss)
    {
        _bossData = data;
        _animator = animator;
        _target = target;
        _rigidbody = rigidbody;
    }

    public override void Enter()
    {
        base.Enter();

        _animator.SetBool("isDodging", true);

        Debug.Log("DODGE");

        Vector2 targetDirection = _target.position - Boss.transform.position;
        Vector2 rightDirection = Vector2.right;

        float dotProduct = Vector2.Dot(targetDirection, rightDirection);

        if (dotProduct < 0)
            _rigidbody.velocity = new Vector2(_bossData.DodgeSpeed, 0f);
        else
            _rigidbody.velocity = new Vector2(-_bossData.DodgeSpeed, 0f);
    }

    public override void Exit()
    {
        base.Exit();
        _animator.SetBool("isDodging", false);
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
}