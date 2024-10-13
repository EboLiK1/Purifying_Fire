using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region Данные
    [Header("Данные")]
    [SerializeField] private BossData _bossData;
    public Transform Target { get; private set; }
    #endregion

    #region Компоненты
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private BossStateMachine _bossStateMachine;
    public BossStage CurrentStage;
    private BossHealth _bossHealth;
    private BossAnimationToFSM _bossAnimationToFSM;
    #endregion


    [HideInInspector] public bool FaceRight = true;
    public bool CanTakeLongAttack;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _bossHealth = GetComponent<BossHealth>();
        _bossAnimationToFSM = GetComponent<BossAnimationToFSM>();
        Target = FindObjectOfType<Player>().transform;

        _bossStateMachine = new BossStateMachine();

        _bossStateMachine.AddState(new BossRunState(_bossStateMachine, this, _bossData, _animator, Target));
        _bossStateMachine.AddState(new BossAttackState(_bossStateMachine, this, _bossData, _animator, Target, _bossAnimationToFSM));
        _bossStateMachine.AddState(new BossLongAttackState(_bossStateMachine, this, _bossData, _animator, Target, _bossAnimationToFSM, _rigidbody));
        _bossStateMachine.AddState(new BossHealState(_bossStateMachine, this, _bossData, _animator, _bossHealth, _bossAnimationToFSM));
        _bossStateMachine.AddState(new BossGetDamageState(_bossStateMachine, this, _bossData, _animator, _bossAnimationToFSM));
        _bossStateMachine.AddState(new BossDodgeState(_bossStateMachine, this, _bossData, _animator, Target, _rigidbody));

        _bossStateMachine.SetState<BossRunState>();

        CurrentStage = BossStage.Stage1;

        _bossHealth.OnChangeState += SetHealState;
        _bossHealth.OnGetDamage += SetGetDamageState;
        _bossHealth.OnDamageDintPass += SetDodgeState;

        CanTakeLongAttack = true;
    }

    private void Update()
    {
        //Debug.Log($"Т Состояние {_bossStateMachine.GetCurrentState()}" +
        //          $"П Состояние {_bossStateMachine.GetPreviousState()}");
        _bossStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _bossStateMachine.FixedUpdate();
    }

    #region Назначение состояний
    private void SetHealState() =>
        _bossStateMachine.SetState<BossHealState>();

    private void SetDodgeState() =>
        _bossStateMachine.SetState<BossDodgeState>();

    private void SetGetDamageState() =>
        _bossStateMachine.SetState<BossGetDamageState>();
    #endregion

    public IEnumerator LongAttackCooldown()
    {
        yield return new WaitForSeconds(_bossData.LongAttackCooldown);

        CanTakeLongAttack = true;
    }

    public void SetZeroVelocity() =>
        _rigidbody.velocity = Vector2.zero;

    public void Flip()
    {
        FaceRight = !FaceRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

public enum BossStage
{
    Stage1,
    Stage2
}









//Debug.Log($"Т Состояние {_bossStateMachine.GetCurrentState()}" +
//          $"П Состояние {_bossStateMachine.GetPreviousState()}");
