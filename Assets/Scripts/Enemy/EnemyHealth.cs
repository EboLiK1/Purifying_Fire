using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
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
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Enemy _enemy;
    #endregion

    #region Другое
    private Vector2 currentVelocity;
    #endregion

    public CameraController CameraController;

    public Action OnGetDamage;
    public Action OnDead;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemy = GetComponent<Enemy>();
    }

    public void Damage(float amount, Transform attackPosition)
    {
        if (_enemy.IsDead)
            return;

        OnGetDamage?.Invoke();

        _health -= amount;

        _spriteRenderer.material = _blinkMaterial;
        Invoke(nameof(ResetBlinkMaterial), _blinkDuration);

        if (_health <= 0f)
        {
            OnDead?.Invoke();
            _enemy.IsDead = true;
        }

        CameraController.Shake();
    }

    private void ResetBlinkMaterial() =>
        _spriteRenderer.material = _normalMaterial;

    public void Knockback(float knockbackX, float knockbackY, Transform attackPosition)
    {
        if (_enemy.IsDead)
            return;

        Vector2 attackDirection = (_rigidbody.transform.position - attackPosition.position).normalized;

        currentVelocity.Set(attackDirection.x * knockbackX, knockbackY);
        _rigidbody.velocity = currentVelocity;
    }
}