using System;
using UnityEngine;

public class ActionHitBoxComponent : WeaponComponent
{
    public event Action<Collider2D[]> OnDetectedCollider2D;

    private Vector2 _offset;

    private Collider2D[] _detected;

    private ActionHitBoxComponentData _data;

    protected override void Start()
    {
        base.Start();

        _data = Weapon.Data.GetData<ActionHitBoxComponentData>();
        Weapon.AnimationEventHandler.OnAttackAction += HandleAttackAction;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Weapon.AnimationEventHandler.OnAttackAction -= HandleAttackAction;
    }

    private void HandleAttackAction()
    {
        _offset.Set(
            transform.position.x + _data.AttackData[Weapon.CurrentAttackCounter].HitBox.center.x * (Weapon.FaceRight ? 1 : -1),
            transform.position.y + _data.AttackData[Weapon.CurrentAttackCounter].HitBox.center.y
        );

        _detected = Physics2D.OverlapBoxAll(_offset, _data.AttackData[Weapon.CurrentAttackCounter].HitBox.size, 0f, _data.DetectableLayers);

        if (_detected.Length == 0)
            return;

        OnDetectedCollider2D?.Invoke(_detected);
    }

    private void OnDrawGizmos()
    {
        if (_data == null)
            return;

        foreach (var item in _data.AttackData)
        {
            if (!item.Debug)
                continue;

            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
        }
    }
}
