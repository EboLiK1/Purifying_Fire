using UnityEngine;

[CreateAssetMenu(fileName = "NewStunData", menuName = "Data/State Data/Stun Data")]
public class StunStateData : ScriptableObject
{
    public float StunTime;
    public float StunKnockbackTime;
    public float StunKnockbackSpeed;
    public Vector2 StunKnockbackAngle;
}
