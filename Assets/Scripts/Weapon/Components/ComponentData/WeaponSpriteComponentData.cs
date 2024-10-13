using UnityEngine;

public class WeaponSpriteComponentData : ComponentData
{
    [field: SerializeField] public AttackSprites[] AttackData { get; private set; }
}