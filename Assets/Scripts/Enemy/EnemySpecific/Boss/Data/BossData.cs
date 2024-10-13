using UnityEngine;

[CreateAssetMenu(fileName = "NewBossData", menuName = "Data/Boss Data/Boss Data")]
public class BossData : ScriptableObject
{
    [field: SerializeField] public float RunSpeed { get; private set; }
    [field: SerializeField] public float DodgeSpeed { get; private set; }
    [field: SerializeField] public float DodgeDuration { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float LongAttackRange { get; private set; }
    [field: SerializeField] public float LongAttackCooldown { get; private set; }
    [field: SerializeField] public float HealAmount { get; private set; }
    [field: SerializeField] public int DodgeChance { get; private set; }
}