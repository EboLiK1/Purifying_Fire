using UnityEngine;

public class DamageComponent : WeaponComponent
{
    private ActionHitBoxComponent _hitBox;
    private DamageComponentData _data;

    protected override void Start()
    {
        base.Start();

        _hitBox = GetComponent<ActionHitBoxComponent>();
        _data = Weapon.Data.GetData<DamageComponentData>();

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
                damageable.Damage(_data.AttackData[Weapon.CurrentAttackCounter].Amount, gameObject.transform);
        }
    }
}