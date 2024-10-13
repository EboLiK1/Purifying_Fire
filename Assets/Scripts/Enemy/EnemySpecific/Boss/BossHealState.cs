using UnityEngine;

public class BossHealState : BossState
{
    private BossData _bossData;
    private Animator _animator;
    private BossHealth _bossHealth;
    private BossAnimationToFSM _bossAnimationToFSM;

    private bool IsHealOver;

    public BossHealState(BossStateMachine bossStateMachine, Boss boss, BossData data, Animator animator, BossHealth bossHealth, BossAnimationToFSM bossAnimationToFSM) :
        base(bossStateMachine, boss)
    {
        _bossData = data;
        _animator = animator;
        _bossHealth = bossHealth;
        _bossAnimationToFSM = bossAnimationToFSM;
    }

    public override void Enter()
    {
        base.Enter();

        _bossAnimationToFSM.BossHealState = this;
        _animator.SetTrigger("isHealing");
        Heal();
        IsHealOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (IsHealOver)
            BossStateMachine.SetState<BossRunState>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void Heal()
    {
        _bossHealth.Heal(_bossData.HealAmount);
    }

    public void FinishAnimation() => IsHealOver = true;
}