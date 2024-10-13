using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region События
    public event Action OnEnter;
    public event Action OnExit;
    #endregion

    [SerializeField] private float _attackCounterResetCooldown;

    public WeaponData Data;

    public int CurrentAttackCounter
    {
        get => _currentAttackCounter;
        private set
        {
            if (value >= Data.NumberOfAttacks)
                _currentAttackCounter = 0;
            else
                _currentAttackCounter = value;
        }
    }

    private Animator _animator;
    public GameObject Base { get; private set; }
    public GameObject WeaponSpriteGameObject { get; private set; }
    public AnimationEventHandler AnimationEventHandler { get; private set; }

    private int _currentAttackCounter;

    private Timer _attackCounterResetTimer;

    public bool FaceRight = true;

    private void Awake()
    {
        Base = transform.Find("Base").gameObject;

        WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
        _animator = Base.GetComponent<Animator>();
        AnimationEventHandler = Base.GetComponent<AnimationEventHandler>();
        _attackCounterResetTimer = new Timer(_attackCounterResetCooldown);
    }

    #region Подписка/Отписка
    private void OnEnable()
    {
        AnimationEventHandler.OnFinish += Exit;
        _attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
    }

    private void OnDisable()
    {
        AnimationEventHandler.OnFinish -= Exit;
        _attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
    }
    #endregion

    private void Update()
    {
        _attackCounterResetTimer.Tick();
    }

    private void ResetAttackCounter() => 
        CurrentAttackCounter = 0;

    public void Enter()
    {
        _attackCounterResetTimer.StopTimer();

        _animator.SetBool("Active", true);
        _animator.SetInteger("Counter", CurrentAttackCounter);

        OnEnter?.Invoke();
    }

    private void Exit()
    {
        _animator.SetBool("Active", false);
        CurrentAttackCounter++;
        _attackCounterResetTimer.StartTimer();
        OnExit?.Invoke();
    }
}