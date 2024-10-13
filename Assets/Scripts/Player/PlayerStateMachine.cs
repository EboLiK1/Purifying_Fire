using System;
using System.Collections.Generic;

public class PlayerStateMachine
{
    private PlayerState StateCurrent { get; set; }
    private PlayerState StatePrevious { get; set; }

    private Dictionary<Type, PlayerState> _states = new Dictionary<Type, PlayerState>();

    public void AddState(PlayerState state) =>
        _states.Add(state.GetType(), state);

    public void SetState<T>() where T : PlayerState
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

    public PlayerState GetCurrentState() => StateCurrent;
    public PlayerState GetPreviousState() => StatePrevious;

    public void Update() => StateCurrent?.Update();
    public void FixedUpdate() => StateCurrent?.FixedUpdate();
}