using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    #region Ёффект удара
    [Header("Ёффект удара")]
    [SerializeField] private Material _blinkMaterial;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private float _blinkDuration;
    #endregion

    private SpriteRenderer _spriteRenderer;
    private Player _player;


    private Vector2 _currentVelocity;

    public Action OnGetDamage;
    public Action OnDead;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }

    public void TakeDamage(float damageAmount, Transform attackPosition)
    {
        OnGetDamage?.Invoke();

        _health -= damageAmount;

        _spriteRenderer.material = _blinkMaterial;

        Invoke(nameof(ResetBlinkMaterial), _blinkDuration);

        if (_health <= 0)
        {
            OnDead?.Invoke();
            return;
        }

        Knockback(6f, 4f, attackPosition);
    }

    public void Knockback(float knockbackX, float knockbackY, Transform attackPosition)
    {
        Vector2 attackDirection = (_player.Rigidbody.transform.position - attackPosition.position).normalized;

        _currentVelocity.Set(attackDirection.x * knockbackX, knockbackY);
        _player.Rigidbody.velocity = _currentVelocity;
    }

    private void ResetBlinkMaterial() =>
        _spriteRenderer.material = _normalMaterial;
}
