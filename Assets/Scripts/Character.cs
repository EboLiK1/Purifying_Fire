using UnityEngine;

public class Character : MonoBehaviour
{
    #region Настройки передвижения
    [Header("Настройки передвижения")]
    public float MoveSpeed;
    public float SmoothTime;
    #endregion

    #region Настройки проверки земли
    [Header("Настройки проверки земли")]
    [SerializeField] protected Transform _groundCheck;
    [SerializeField] protected float _groundCheckRadius;
    [SerializeField] protected LayerMask _ground;
    #endregion

    #region Ссылки
    [HideInInspector] public Rigidbody2D Rigidbody;
    [HideInInspector] public Animator Animator;
    #endregion

    #region Остальная хуйня
    [HideInInspector] public Vector2 MoveDirection;
    [HideInInspector] public Vector2 TargetVelocity;
    [HideInInspector] public Vector2 SlopeNormalPerpendicular;
    [HideInInspector] public bool FaceRight = true;
    [HideInInspector] public bool IsAttacking;
    [HideInInspector] public bool AttackAnimationFinished;
    [HideInInspector] public float SlopeDownAngle;
    #endregion

    #region Физические материалы
    public PhysicsMaterial2D FullFriction;
    public PhysicsMaterial2D NoFriction;
    #endregion

    public virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    public void FinishAttack() =>
        AttackAnimationFinished = true;
}
