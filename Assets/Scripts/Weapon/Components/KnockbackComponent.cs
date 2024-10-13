using UnityEngine;

public class KnockbackComponent : WeaponComponent
{
    private ActionHitBoxComponent _hitBox;
    private KnockbackComponentData _data;

    protected override void Start()
    {
        base.Start();

        _hitBox = GetComponent<ActionHitBoxComponent>();
        _data = Weapon.Data.GetData<KnockbackComponentData>();

        _hitBox.OnDetectedCollider2D += HandleDetectedCollider2D;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _hitBox.OnDetectedCollider2D -= HandleDetectedCollider2D;
    }

    public void HandleDetectedCollider2D(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            if (item.TryGetComponent(out IDamageable damageable))
                damageable.Knockback(_data.KnockbackData[Weapon.CurrentAttackCounter].KnockbackX, 
                                     _data.KnockbackData[Weapon.CurrentAttackCounter].KnockbackY,
                                     gameObject.transform);
        }
    }
}