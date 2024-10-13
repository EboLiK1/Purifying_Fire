using UnityEngine;

public interface IDamageable
{
    void Damage(float amount, Transform attackPosition);
    void Knockback(float knockbackX, float knockbackY, Transform attackPosition);
}