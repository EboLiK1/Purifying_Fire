using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<PlayerHealth>() != null)
            obj.GetComponent<PlayerHealth>().TakeDamage(100, transform);
    }
}
