using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackData", menuName = "Data/State Data/Attack Data")]
public class MeleeAttackStateData : ScriptableObject
{
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackDistance;

    public float DamageAmount => _damageAmount;
    public float AttackDistance => _attackDistance;
}
