using UnityEngine;

public class EnemyMeleeCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackZone;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _player;

    public void Damage(float damageAmount)
    {
        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(_attackZone.position, _attackRadius, _player);

        foreach (Collider2D collider in detectedObject)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackZone.position, _attackRadius);
    }
}