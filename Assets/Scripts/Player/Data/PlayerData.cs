using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallSlideSpeed;
    [SerializeField] private Vector2 _wallJumpAngle;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _distanceBetweenImage;

    public float MoveSpeed => _moveSpeed;
    public float CrouchSpeed => _crouchSpeed;
    public float DashSpeed => _dashSpeed;
    public float JumpForce => _jumpForce;
    public float WallSlideSpeed => _wallSlideSpeed;
    public Vector2 WallJumpAngle => _wallJumpAngle;
    public float SmoothTime => _smoothTime;
    public float DashCooldown => _dashCooldown;
    public float DashDuration => _dashDuration;
    public float DistanceBetweenImage => _distanceBetweenImage;

    public Vector2 StartOffset;
    public Vector2 StopOffset;
}
