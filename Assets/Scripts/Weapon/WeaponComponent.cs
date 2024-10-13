using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon Weapon;

    protected bool IsAttackActive;

    protected virtual void Start()
    {
        Weapon = GetComponent<Weapon>();

        Weapon.OnEnter += HandleEnter;
        Weapon.OnExit += HandleExit;
    }

    protected virtual void OnDisable()
    {
        Weapon.OnEnter -= HandleEnter;
        Weapon.OnExit -= HandleExit;
    }

    protected virtual void HandleEnter() =>
        IsAttackActive = true;

    protected virtual void HandleExit() =>
        IsAttackActive = false;
}