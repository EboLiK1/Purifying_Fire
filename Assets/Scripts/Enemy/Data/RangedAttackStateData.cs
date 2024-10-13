using UnityEngine;

[CreateAssetMenu(fileName = "NewRangeAttackData", menuName = "Data/State Data/Range Attack Data")]
public class RangedAttackStateData : ScriptableObject
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _projectileDamage;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileTravelDistance;

    public GameObject Projectile => _projectile;
    public float ProjectileDamage => _projectileDamage;
    public float ProjectileSpeed => _projectileSpeed;
    public float ProjectileTravelDistance => _projectileTravelDistance;
}
