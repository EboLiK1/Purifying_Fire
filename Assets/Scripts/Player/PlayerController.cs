using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Поля
    #region Название анимаций
    private const string MOVE_X = "MoveX";
    private const string SQUAT = "Squat";
    private const string DASH = "isDashing";
    private const string JUMP = "isJumping";
    private const string FALL = "isFalling";
    private const string WALL_SLIDING = "isWallSliding";
    #endregion

    #region Настройки передвижения
    [Header("Настройки перемещения")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallJumpForce;
    [SerializeField] private float _wallJumpHorizontalForce;
    [SerializeField] private float _wallSlideSpeed;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _distanceBetweemImages;
    [SerializeField] private float _dashCoolDown;
    [SerializeField] private float _dashDuration;
    #endregion

    #region Настройки атаки
    
    #endregion

    #region Настройки проверки земли
    [Header("Настройки проверки земли")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _ground;
    #endregion

    #region Настройки проверки потолка
    [Header("Настройки проверки потолка")]
    [SerializeField] private Transform _topCheck;
    [SerializeField] private float _topCheckRadius;
    [SerializeField] private LayerMask _roof;
    #endregion

    #region Настройки проверки стены
    [Header("Настройки проверки стены")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckDistance;
    [SerializeField] private LayerMask _wall;
    #endregion

    #region Коллайдеры игрока
    [Header("Коллайдеры игрока")]
    [SerializeField] private CapsuleCollider2D _poseStand;
    [SerializeField] private CapsuleCollider2D _poseSquat;
    #endregion

    #region Материалы
    [field: SerializeField] PhysicsMaterial2D _fullFriction;
    [SerializeField] PhysicsMaterial2D _noFriction;
    #endregion

    [SerializeField] GameObject _residualImage;

    #region Остальная хуйня
    private Vector2 _moveDirection;
    private Vector2 _targetVelocity;
    private Vector2 _slopeNormalPerpendicular;
    private Vector2 _nullVector = Vector2.zero;

    //private PlayerInput _playerInput;
    private ThroughPlatformHandler _throughPlatformHandler;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private float _dashTimer;
    private float _lastImageXPosition;
    private float _slopeDownAngle;

    private bool _faceRight = true;

    private bool _isWalking
    {
        get => _moveDirection != Vector2.zero;
    }

    private bool _isDashing;
    private bool _isJumping;
    private bool _isCrouching;
    private bool _isAttacking = false;
    #endregion
    #endregion

    //private void Awake()
    //{
    //    _playerInput = new PlayerInput();

    //    _playerInput.Player.Move.performed += context => Move();
    //    _playerInput.Player.Jump.performed += context => Jump();
    //    _playerInput.Player.Dash.performed += context => Dash();
    //    _playerInput.Player.JumpOffPlatform.performed += context => JumpOffPlatform();

    //    _playerInput.Player.Crouch.performed += context => Crouch();
    //    _playerInput.Player.Crouch.canceled += context => Stand();
    //    //_playerInput.Player.Attack.performed += context => Attack();

    //    _rigidbody = GetComponent<Rigidbody2D>();
    //    _animator = GetComponent<Animator>();
    //    _throughPlatformHandler = GetComponent<ThroughPlatformHandler>();
    //}

    //private void OnEnable() => _playerInput.Enable();

    //private void OnDisable() => _playerInput.Disable();

    //private void Update()
    //{
    //    _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

    //    UpdateDash();
    //    Move();

    //    if (_rigidbody.velocity.y <= 0f)
    //        _isJumping = false;

    //    _animator.SetBool(FALL, IsFalling());
    //    _animator.SetBool(JUMP, _isJumping);
    //    _animator.SetBool(WALL_SLIDING, IsWallSliding());
    //    _animator.SetFloat(MOVE_X, Mathf.Abs(_moveDirection.x));
    //    _animator.SetBool(SQUAT, _isCrouching);
    //    _animator.SetBool(DASH, _isDashing);
    //}

    #region Методы
    private void Move()
    {
        float targetVelocityX = DetermineTargetVelocityX();

        _slopeNormalPerpendicular = MovementExtension.GetNormalPerpendicular(_groundCheck, _groundCheckRadius, _ground, ref _slopeDownAngle);

        if (IsOnSlope() && IsGrounded() && !_isJumping)
        {
            if(_isDashing)
                _rigidbody.velocity = new Vector2(_faceRight ? _dashSpeed : -_dashSpeed * _slopeNormalPerpendicular.x * -_moveDirection.x,
                                                  _dashSpeed * _slopeNormalPerpendicular.y * -_moveDirection.x);
            if(!_isDashing)
                _rigidbody.velocity = new Vector2(_moveSpeed * _slopeNormalPerpendicular.x * -_moveDirection.x,
                                                  _moveSpeed * _slopeNormalPerpendicular.y * -_moveDirection.x);
        }
        else
        {
            if (_isDashing)
                _rigidbody.velocity = new Vector2(_faceRight ? _dashSpeed : -_dashSpeed, _rigidbody.velocity.y);
            else
            {
                _targetVelocity = new Vector2(targetVelocityX, _rigidbody.velocity.y);
                _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, _targetVelocity, ref _nullVector, _smoothTime);
            }
        }

        if (IsWallSliding())
        {
            if (_rigidbody.velocity.y < -_wallSlideSpeed)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_wallSlideSpeed);
        }

        if (_isWalking && Mathf.Sign(_moveDirection.x) != Mathf.Sign(transform.localScale.x))
            Flip();

        _rigidbody.sharedMaterial = _isWalking ? _noFriction : _fullFriction;
    }

    private float DetermineTargetVelocityX()
    {
        float targetVelocityX = _moveDirection.x * _moveSpeed;

        if (_isDashing)
            targetVelocityX = _moveDirection.x * _dashSpeed;

        if (_isCrouching)
            targetVelocityX = _moveDirection.x * _crouchSpeed;

        return targetVelocityX;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            _isJumping = true;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

        if (IsWallSliding())
        {
            _rigidbody.velocity = new Vector2(_faceRight ? -_wallJumpHorizontalForce : _wallJumpHorizontalForce, _wallJumpForce);
            Flip();
        }
    }

    private void Flip()
    {
        _faceRight = !_faceRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Dash()
    {
        if (!_isDashing)
        {
            _isDashing = true;
            _dashTimer = _dashDuration;
        }
    }

    private void UpdateDash()
    {
        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;

            if (Mathf.Abs(transform.position.x - _lastImageXPosition) > _distanceBetweemImages)
            {
                var residualImage = Instantiate(_residualImage);
                residualImage.transform.localScale = transform.localScale;
                _lastImageXPosition = transform.position.x;
            }

            if (_dashTimer <= 0f)
            {
                _isDashing = false;
                _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
            }
        }
    }

    private void Crouch()
    {
        if (IsGrounded())
        {
            _animator.SetBool(SQUAT, true);
            _poseStand.enabled = false;
            _poseSquat.enabled = true;

            _isCrouching = true;
        }
    }

    private void Stand()
    {
        if (!Physics2D.OverlapCircle(_topCheck.position, _topCheckRadius, _roof))
        {
            _animator.SetBool(SQUAT, false);
            _poseStand.enabled = true;
            _poseSquat.enabled = false;

            _isCrouching = false;
        }
    }

    private void JumpOffPlatform() =>
        _throughPlatformHandler.JumpOffPlatform();

    //private void Attack()
    //{
    //    _isAttacking = true;
    //}

    //private void FinishAttack()
    //{
    //    _isAttacking = false;
    //}

    #region Проверки
    private bool IsGrounded() =>
        Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);

    private bool IsOnSlope() =>
        _slopeDownAngle > 0f;

    private bool IsFalling() =>
        _rigidbody.velocity.y < 0f && !IsOnSlope();

    private bool IsTouchingWall() =>
        Physics2D.Raycast(_wallCheck.position, new Vector2(transform.localScale.x, 0f), _wallCheckDistance, _wall);

    private bool IsWallSliding() =>
        IsTouchingWall() && !IsGrounded() && _rigidbody.velocity.y < 0f;
    #endregion

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(_topCheck.position, _topCheckRadius);

    //    Gizmos.color = Color.white;
    //    Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);

    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(_wallCheck.position, _wallCheckDistance);
    //}
    #endregion
}