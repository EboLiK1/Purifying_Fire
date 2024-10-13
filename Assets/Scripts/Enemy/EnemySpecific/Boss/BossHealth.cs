using System;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    public Action OnGetDamage;
    public Action OnChangeState;
    public Action OnDamageDintPass;
    public Action OnDead;

    #region Здоровье
    [Header("Здоровье")]
    [SerializeField] private float _health;
    #endregion

    #region Эффект удара
    [Header("Эффект удара")]
    [SerializeField] private Material _blinkMaterial;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private float _blinkDuration;
    #endregion

    #region Компоненты
    private Boss _boss;
    #endregion

    private bool _isFirstHeal = true;

    public CameraController CameraController;

    private void Start()
    {
        _boss = GetComponent<Boss>();
    }

    public void Damage(float amount, Transform attackPosition)
    {
        System.Random random = new System.Random();
        int randomChance = random.Next(1, 101);

        if (50f >= randomChance)
        {
            OnDamageDintPass?.Invoke();
            return;
        }

        _health -= amount;

        OnGetDamage?.Invoke();
        CameraController.Shake();

        if (_health <= 0f && _boss.CurrentStage == BossStage.Stage1)
            _boss.CurrentStage = BossStage.Stage2;

        if (_boss.CurrentStage == BossStage.Stage2 && _isFirstHeal)
        {
            _isFirstHeal = false;
            OnChangeState?.Invoke();
        }

        if (_boss.CurrentStage == BossStage.Stage2 && !_isFirstHeal && _health <= 0f)
            SceneSwitcher.Instance.LoadScene("Boss_Final");

        Debug.Log(_health);
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

    public void Knockback(float knockbackX, float knockbackY, Transform attackPosition)
    {
        //throw new System.NotImplementedException();
    }
}