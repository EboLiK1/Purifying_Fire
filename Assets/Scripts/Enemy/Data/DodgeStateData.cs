using UnityEngine;

[CreateAssetMenu(fileName = "NewDodgeData", menuName = "Data/State Data/Dodge Data")]
public class DodgeStateData : ScriptableObject
{
    [SerializeField] private float _dodgeSpeed;
    [SerializeField] private float _dodgeTime;
    [SerializeField] private float _dodgeCooldown;
    [SerializeField] private Vector2 _dodgeAngle;

    public float DodgeSpeed => _dodgeSpeed;
    public float DodgeTime => _dodgeTime;
    public float DodgeCooldown => _dodgeCooldown;
    public Vector2 DodgeAngle => _dodgeAngle;
}
