using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float _attackRadius;
    public LayerMask _player;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _player);

        foreach (Collider2D collide in detectedObject)
        {
            PlayerHealth playerHealth = collide.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1f, transform);
        }
    }
}