using UnityEngine;

public class ActionHitBoxComponentData : ComponentData
{
    [field: SerializeField] public AttackActionHitBox[] AttackData{ get; private set; }
    [field: SerializeField] public LayerMask DetectableLayers { get; private set; }
}