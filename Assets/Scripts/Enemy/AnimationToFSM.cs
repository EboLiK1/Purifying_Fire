using UnityEngine;

public class AnimationToFSM : MonoBehaviour
{
    public AttackState AttackState;
    public GetDamageState GetDamageState;
    public PlayerGetDamageState PlayerGetDamageState;
    public BossHealState BossHealState;

    private void TriggerAttack() => AttackState.TriggerAttack();
    private void FinishAttack() => AttackState.FinishAttack();
    private void FinishGetDamageState() => GetDamageState.FinishAttack();
    private void FinishPlayerGetDamageState() => PlayerGetDamageState.FinishAnimationTrigger();
}
