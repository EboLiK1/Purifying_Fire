using System;
using System.Collections.Generic;

public class BossStateMachine
{
    private BossState StateCurrent { get; set; }
    private BossState StatePrevious { get; set; }

    private Dictionary<Type, BossState> _states = new Dictionary<Type, BossState>();

    public void AddState(BossState state) =>
        _states.Add(state.GetType(), state);

    public void SetState<T>() where T : BossState
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

    public BossState GetPreviousState() => StatePrevious;
    public BossState GetCurrentState() => StateCurrent;

    public void Update() => StateCurrent?.Update();
    public void FixedUpdate() => StateCurrent?.FixedUpdate();
}