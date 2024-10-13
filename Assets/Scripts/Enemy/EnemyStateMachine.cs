using System;
using System.Collections.Generic;

public class EnemyStateMachine
{
    private EnemyState StateCurrent { get; set; }
    private EnemyState StatePrevious { get; set; }

    private Dictionary<Type, EnemyState> _states = new Dictionary<Type, EnemyState>();

    public void AddState(EnemyState state) =>
        _states.Add(state.GetType(), state);

    public void SetState<T>() where T : EnemyState
    {
        var type = typeof(T);

        if (StateCurrent != null && StateCurrent.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            StatePrevious = StateCurrent;
            StateCurrent?.Exit();
            StateCurrent = newState;
            StateCurrent.Enter();
        }
    }

    public EnemyState GetPreviousState() => StatePrevious;
    public EnemyState GetCurrentState() => StateCurrent;

    public void Update() => StateCurrent?.Update();
    public void FixedUpdate() => StateCurrent?.FixedUpdate();
}
