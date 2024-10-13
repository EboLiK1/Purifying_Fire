using UnityEngine;

public class KnockbackComponentData : ComponentData
{
    [field: SerializeField] public AttackKnockback[] KnockbackData { get; private set; }
}