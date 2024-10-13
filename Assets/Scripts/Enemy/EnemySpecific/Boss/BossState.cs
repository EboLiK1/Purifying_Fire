using UnityEngine;

public class BossState
{
    protected readonly BossStateMachine BossStateMachine;
    protected readonly Boss Boss;
    protected float StartTime;

    public BossState(BossStateMachine bossStateMachine, Boss boss)
    {
        BossStateMachine = bossStateMachine;
        Boss = boss;
    }

    public virtual void Enter() { StartTime = Time.time; }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}