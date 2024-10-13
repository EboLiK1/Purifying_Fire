using UnityEngine;

public class WeaponSpriteComponent : WeaponComponent
{
    private SpriteRenderer _baseSpriteRenderer;
    private SpriteRenderer _weaponSpriteRenderer;

    private int _currentWeaponSpriteIndex;

    private WeaponSpriteComponentData _data;

    protected override void Start()
    {
        base.Start();

        _baseSpriteRenderer = transform.Find("Base").GetComponent<SpriteRenderer>();
        _weaponSpriteRenderer = transform.Find("WeaponSprite").GetComponent<SpriteRenderer>();

        _data = Weapon.Data.GetData<WeaponSpriteComponentData>();

        _baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
        Weapon.OnEnter += HandleEnter;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);
        Weapon.OnEnter -= HandleEnter;
    }

    private void HandleBaseSpriteChange(SpriteRenderer spriteRenderer)
    {
        if (!IsAttackActive)
        {
            _weaponSpriteRenderer.sprite = null;
            return;
        }

        var currentAttackSprite = _data.AttackData[Weapon.CurrentAttackCounter].Sprites;

        if (_currentWeaponSpriteIndex >= currentAttackSprite.Length)
            return;

        _weaponSpriteRenderer.sprite = currentAttackSprite[_currentWeaponSpriteIndex];
        _currentWeaponSpriteIndex++;
    }

    protected override void HandleEnter()
    {
        base.HandleEnter();

        _currentWeaponSpriteIndex = 0;
    }
}