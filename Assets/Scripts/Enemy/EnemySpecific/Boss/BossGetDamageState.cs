using UnityEngine;

public class BossGetDamageState : BossState
{
    private BossData _bossData;
    private Animator _animator;
    private BossAnimationToFSM _bossAnimationToFSM;

    private bool _isAnimationFinished;

    public BossGetDamageState(BossStateMachine bossStateMachine, Boss boss, BossData data, Animator animator, BossAnimationToFSM bossAnimationToFSM) :
        base(bossStateMachine, boss)
    {
        _bossData = data;
        _animator = animator;
        _bossAnimationToFSM = bossAnimationToFSM;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("ENTER GET DAMAGE");

        _isAnimationFinished = false;
        _bossAnimationToFSM.BossGetDamageState = this;
        _animator.SetTrigger("GetDamage");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (_isAnimationFinished)
            BossStateMachine.SetState<BossRunState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Damage()
    {

    }

    public void FinishGetDamage() => _isAnimationFinished = true;
}