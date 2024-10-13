using UnityEngine;

public class DamageComponentData : ComponentData
{
    [field: SerializeField] public AttackDamage[] AttackData { get; private set; }
}