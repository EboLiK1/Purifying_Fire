using UnityEngine;

public class BossAnimationToFSM : MonoBehaviour
{
    public BossHealState BossHealState;
    public BossAttackState BossAttackState;
    public BossLongAttackState BossLongAttackState;
    public BossGetDamageState BossGetDamageState;

    private void FinishHeal() => BossHealState.FinishAnimation();
    private void FinishAttack() => BossAttackState.FinishAttack();
    private void FinishLongAttack() => BossLongAttackState.FinishAttack();
    private void FinishGetDamage() => BossGetDamageState.FinishGetDamage();
}