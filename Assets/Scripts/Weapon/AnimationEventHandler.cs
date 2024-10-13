using System;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public event Action OnFinish;
    public event Action OnAttackAction;

    private void AnimationFinishedTrigger() =>
        OnFinish?.Invoke();

    private void AttackActionTrigger() =>
        OnAttackAction?.Invoke();
}