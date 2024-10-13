using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Настройки передвижения
    public Transform LeftPoint;
    public Transform RightPoint;
    [HideInInspector] public Transform CurrentTarget;
    [HideInInspector] public Transform PreviousTarget;
    #endregion

    #region Настройки проверки на игрока
    [SerializeField] private Transform _playerCheck;
    [SerializeField] private float _playerCheckDistance;
    [SerializeField] private LayerMask _player;
    #endregion

    #region Настройки проверки земли
    [Header("Настройки проверки земли")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _ground;
    #endregion

    #region Настройки проверки уступа
    [SerializeField] private Transform _ledgeCheck;
    [SerializeField] private float _ledgeCheckDistance;
    [SerializeField] private LayerMask _ledge;
    #endregion

    #region Ссылки
    [HideInInspector] public Rigidbody2D Rigidbody;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public EnemyMeleeCombat EnemyMeleeCombat;
    [HideInInspector] public AnimationToFSM AnimationToFSM;
    [HideInInspector] public EnemyStateMachine EnemyStateMachine;
    [HideInInspector] public Transform PlayerZapasnoy;
    #endregion

    #region Остальная хуйня
    [HideInInspector] public bool FaceRight = true;
    private Vector2 _velocityWorkspace;
    #endregion

    public float MaxAttackDistance;
    public float MinAttackDistance;
    [HideInInspector] public bool IsDead;

    [SerializeField] private float _closeRangeAction;
    [SerializeField] private float _longRangeAction;

    public virtual void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        EnemyMeleeCombat = GetComponent<EnemyMeleeCombat>();
        AnimationToFSM = GetComponent<AnimationToFSM>();
        PlayerZapasnoy = FindObjectOfType<Player>().transform;
        GetComponent<EnemyHealth>();

        EnemyStateMachine = new EnemyStateMachine();

        CurrentTarget = LeftPoint;
        PreviousTarget = RightPoint;
    }

    public virtual void Update()
    {
        Debug.Log($"Т Состояние {EnemyStateMachine.GetCurrentState()}" +
                  $"П Состояние {EnemyStateMachine.GetPreviousState()}");

        EnemyStateMachine.Update();
    }

    public virtual void FixedUpdate()
    {
        EnemyStateMachine.FixedUpdate();
    }

    #region Передвижение
    public void SetZeroVelocity() =>
        Rigidbody.velocity = Vector2.zero;

    public virtual void SetDodgeVelocity(float speed)
    {
        _velocityWorkspace.Set(speed, 0f);
        Rigidbody.velocity = _velocityWorkspace;
    }

    public void MoveTowardsTarget(float moveSpeed)
    {
        Vector2 direction = (CurrentTarget.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        bool isWalking = direction.x != 0f;

        if (isWalking && Mathf.Sign(direction.x) != Mathf.Sign(transform.localScale.x))
            Flip();
    }

    public void FlipTowardsPlayer()
    {
        if (CurrentTarget.position.x < transform.position.x && FaceRight)
            Flip();
        else if (CurrentTarget.position.x > transform.position.x && !FaceRight)
            Flip();
    }

    public virtual void Flip()
    {
        FaceRight = !FaceRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    #endregion

    #region Проверки
    public virtual bool IsPlayerDetected()
    {
        RaycastHit2D player = Physics2D.Raycast(_playerCheck.position, new Vector2(transform.localScale.x, 0f), _playerCheckDistance, _player);

        if (player)
            CurrentTarget = player.transform;

        return player;
    }

    public bool IsGrounded() =>
    Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);

    public virtual bool IsOnLedge() =>
        Physics2D.Raycast(_ledgeCheck.position, Vector2.down, _ledgeCheckDistance, _ledge);

    public virtual bool IsPlayerInMinAgroRange() =>
        Physics2D.Raycast(_playerCheck.position, new Vector2(transform.localScale.x, 0f), MinAttackDistance, _player);

    public virtual bool IsPlayerInMaxAgroRange() =>
        Physics2D.Raycast(_playerCheck.position, new Vector2(transform.localScale.x, 0f), MaxAttackDistance, _player);

    public virtual bool IsPlayerInCloseRangeAction() =>
        Physics2D.Raycast(_playerCheck.position, new Vector2(transform.localScale.x, 0f), _closeRangeAction, _player);

    public virtual bool IsPlayerInLongRangeAction() =>
        Physics2D.Raycast(_playerCheck.position, new Vector2(transform.localScale.x, 0f), _longRangeAction, _player);
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_playerCheck.position, new Vector2(transform.localScale.x, 0f) * _playerCheckDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_ledgeCheck.position, _ledgeCheck.position + (Vector3)(Vector2.down * _ledgeCheckDistance));

        Gizmos.DrawRay(_playerCheck.position, new Vector2(transform.localScale.x, 0f) * MaxAttackDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(_playerCheck.position, new Vector2(transform.localScale.x, 0f) * MinAttackDistance);
    }
}
