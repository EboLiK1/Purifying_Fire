using System.Collections;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    #region Настройки передвижения
    [Header("Настройки передвижения")]
    public PlayerData PlayerData;
    [SerializeField] private Transform _jumpPoint;
    #endregion

    #region Настройки проверки земли
    [Header("Настройки проверки земли")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _ground;
    #endregion

    #region Настройки проверки потолка
    [Header("Настройки проверки потолка")]
    [SerializeField] private Transform _ceilingCheck;
    [SerializeField] private float _ceilingCheckRadius;
    [SerializeField] private LayerMask _ceiling;
    #endregion

    #region Настройки проверки стены
    [Header("Настройки проверки стены")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckDistance;
    [SerializeField] private LayerMask _wall;
    #endregion

    #region Настройки проверки уступа
    [Header("Настройки проверки уступа")]
    [SerializeField] private Transform _ledgeCheck;
    [SerializeField] private float _ledgeCheckDistance;
    [SerializeField] private LayerMask _ledge;
    #endregion

    #region Коллайдеры игрока
    [Header("Коллайдеры игрока")]
    public Collider2D StandCollider;
    public Collider2D CrouchCollider;
    #endregion

    public PhysicsMaterial2D FullFriction;
    public PhysicsMaterial2D NoFriction;

    #region Ссылки
    [HideInInspector] public Rigidbody2D Rigidbody;
    [HideInInspector] public Animator Animator;
    public GameObject JumpEffect;
    public GameObject LandEffect;
    //[HideInInspector] public PlayerInputActions PlayerInput;
    [HideInInspector] public ThroughPlatformHandler ThroughPlatformHandler;
    //[HideInInspector] public PlayerCombat PlayerCombat;
    private PlayerStateMachine _playerStateMachine;
    private Weapon _weapon;
    private PlayerHealth _playerHealth;
    [HideInInspector] public AnimationToFSM AnimationToFSM;
    #endregion

    #region Остальная хуйня
    [HideInInspector] public Vector2 MoveDirection;
    [HideInInspector] public Vector2 TargetVelocity;
    [HideInInspector] public Vector2 SlopeNormalPerpendicular;
    [HideInInspector] public bool FaceRight = true;
    [HideInInspector] public bool IsJumping;
    [HideInInspector] public bool IsJumpingOffPlatform;
    [HideInInspector] public bool IsCrouching;
    [HideInInspector] public bool IsDashing;
    [HideInInspector] public bool CanDash;
    [HideInInspector] public bool IsAttacking;
    [HideInInspector] public bool AttackAnimationFinished;
    [HideInInspector] public float LastImageXPosition;
    [HideInInspector] public float SlopeDownAngle;
    #endregion

    public GameObject canvas;

    public GameInput GameInput;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        ThroughPlatformHandler = GetComponent<ThroughPlatformHandler>();
        //PlayerCombat = GetComponent<PlayerCombat>();
        _weapon = transform.Find("Weapon").GetComponent<Weapon>();
        _playerHealth = GetComponent<PlayerHealth>();
        AnimationToFSM = GetComponent<AnimationToFSM>();

        //PlayerInput = new PlayerInputActions();
        Game.Instance.GameInput.Player.Jump.started += contex => IsJumping = true;
        Game.Instance.GameInput.Player.Jump.canceled += contex => IsJumping = false;
        Game.Instance.GameInput.Player.Crouch.started += contex => IsCrouching = true;
        Game.Instance.GameInput.Player.Crouch.canceled += contex => IsCrouching = false;
        Game.Instance.GameInput.Player.Dash.started += contex => IsDashing = true;
        Game.Instance.GameInput.Player.Attack.started += contex => IsAttacking = true;
        Game.Instance.GameInput.Player.JumpOffPlatform.performed += context => JumpOffPlatform();

        _playerStateMachine = new PlayerStateMachine();

        _playerStateMachine.AddState(new PlayerIdleState(_playerStateMachine, this, _jumpPoint));
        _playerStateMachine.AddState(new PlayerRunState(_playerStateMachine, this));
        _playerStateMachine.AddState(new PlayerCrouchState(_playerStateMachine, this));
        _playerStateMachine.AddState(new PlayerDashState(_playerStateMachine, this));
        _playerStateMachine.AddState(new PlayerFallState(_playerStateMachine, this));
        _playerStateMachine.AddState(new PlayerJumpState(_playerStateMachine, this, _jumpPoint));
        _playerStateMachine.AddState(new PlayerAttackState(_playerStateMachine, this, _weapon));
        _playerStateMachine.AddState(new PlayerGetDamageState(_playerStateMachine, this));
        _playerStateMachine.AddState(new PlayerDeathState(_playerStateMachine, this));
        //_playerStateMachine.AddState(new PlayerLedgeClimbState(_playerStateMachine, this));
        //_playerStateMachine.AddState(new PlayerWallSlideState(_playerStateMachine, this));

        _playerHealth.OnGetDamage += SetGetDamageState;
        _playerHealth.OnDead += SetDeathState;

        _playerStateMachine.SetState<PlayerIdleState>();

        CanDash = true;
    }

    //[Inject]
    //public void Initialize(GameInput gameInput)
    //{
    //    GameInput = gameInput;
    //}

    private void OnEnable() => Game.Instance.GameInput.Enable();

    private void OnDisable() => Game.Instance.GameInput.Disable();

    private void Update()
    {
        MoveDirection = Game.Instance.GameInput.Player.Move.ReadValue<Vector2>();

        SlopeNormalPerpendicular = MovementExtension.GetNormalPerpendicular(_groundCheck, _groundCheckRadius, _ground, ref SlopeDownAngle);

        _playerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _playerStateMachine.FixedUpdate();
    }

    private void SetGetDamageState() =>
        _playerStateMachine.SetState<PlayerGetDamageState>();

    private void SetDeathState() =>
        _playerStateMachine.SetState<PlayerDeathState>();

    public void Flip()
    {
        FaceRight = !FaceRight;
        _weapon.FaceRight = FaceRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetVelocity(float velocity, Vector2 angle)
    {
        angle.Normalize();
        Rigidbody.velocity = new Vector2(FaceRight ? -(angle.x * velocity) : (angle.x * velocity), angle.y * velocity);
    }

    public void SetZeroVelocity() =>
        Rigidbody.velocity = Vector2.zero;

    private void JumpOffPlatform()
    {
        ThroughPlatformHandler.JumpOffPlatform();
        IsJumpingOffPlatform = true;
        _playerStateMachine.SetState<PlayerFallState>();
    }
        
    public void FinishAttack() =>
        AttackAnimationFinished = true;

    #region Проверки
    public bool IsGrounded() =>
        Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);

    public bool IsCeilingAbove() =>
        Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingCheckRadius, _ceiling);

    public bool IsFalling() =>
        Rigidbody.velocity.y < 0f && !IsGrounded();

    public bool IsTouchingWall() =>
        Physics2D.Raycast(_wallCheck.position, new Vector2(transform.localScale.x, 0f), _wallCheckDistance, _wall);

    public bool IsTouchingLedge() =>
        Physics2D.Raycast(_ledgeCheck.position, new Vector2(transform.localScale.x, 0f), _ledgeCheckDistance, _ledge);

    public bool IsOnSlope() =>
        SlopeDownAngle > 0f;
    #endregion

    public Vector2 GetNormalPerpendicular(ref float slopeDownAngle) =>
        MovementExtension.GetNormalPerpendicular(_groundCheck, _groundCheckRadius, _ground, ref slopeDownAngle);

    public IEnumerator DashCooldownTimer()
    {
        yield return new WaitForSeconds(PlayerData.DashCooldown);

        CanDash = true;
    }

    private void StartAnimationTrigger() => _playerStateMachine.GetCurrentState().StartAnimationTrigger();
    private void FinishAnimationTrigger() => _playerStateMachine.GetCurrentState().FinishAnimationTrigger();

    #region Для карабканья на стены и скольжение
    private void DrawRay(Vector2 origin, Vector2 direction, float distance, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(origin, direction * distance);
    }
    private void OnDrawGizmos()
    {
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(_ceilingCheck.position, _ceilingCheckRadius);

        //    Gizmos.color = Color.white;
        //    Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);

        //    Gizmos.color = Color.green;
        //    Gizmos.DrawWireSphere(_wallCheck.position, _wallCheckDistance);
        DrawRay(_wallCheck.position, new Vector2(transform.localScale.x, 0f), _wallCheckDistance, Color.red);
        DrawRay(_ledgeCheck.position, new Vector2(transform.localScale.x, 0f), _ledgeCheckDistance, Color.blue);
    }
    private Vector2 DetectedPosition;
    public void SetDetectedPosition(Vector3 position) =>
        DetectedPosition = position;
    public Vector3 GetDetectedPosition() => DetectedPosition;

    public Vector2 workspace;
    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(_wallCheck.position, new Vector2(transform.localScale.x, 0f), _wallCheckDistance, _wall);
        float xDistance = xHit.distance;
        workspace.Set((xDistance + 0.015f) * (FaceRight ? 1 : -1), 0f);
        RaycastHit2D yHit = Physics2D.Raycast(_ledgeCheck.position + (Vector3)(workspace), Vector2.down, _ledgeCheck.position.y - _wallCheck.position.y + 0.015f, _ground);
        float yDistance = yHit.distance;

        workspace.Set(_wallCheck.position.x + (xDistance * (FaceRight ? 1 : -1)), _ledgeCheck.position.y - yDistance);

        return workspace;
    }
    #endregion
}