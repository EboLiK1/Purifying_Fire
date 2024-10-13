using UnityEngine;

public class EnemyState
{
    protected readonly EnemyStateMachine EnemyStateMachine;
    protected readonly Enemy Enemy;
    protected float StartTime;

    public EnemyState(EnemyStateMachine enemyStateMachine, Enemy enemy)
    {
        EnemyStateMachine = enemyStateMachine;
        Enemy = enemy;
    }

    public virtual void Enter() { StartTime = Time.time; }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}
