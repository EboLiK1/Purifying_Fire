using System.Collections;
using UnityEngine;

public class ThroughPlatformHandler : MonoBehaviour
{
    #region Коллайдеры игрока
    [Header("Коллайдеры игрока")]
    [SerializeField] private CapsuleCollider2D StandCollider;
    [SerializeField] private CapsuleCollider2D CrouchCollider;
    #endregion

    public GameObject CurrentOneWayPlatform { get; private set; }

    public void JumpOffPlatform()
    {
        if (CurrentOneWayPlatform != null)
            StartCoroutine(DisableCollision());
    }

    private IEnumerator DisableCollision()
    {
        Collider2D platformCollider = CurrentOneWayPlatform.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(StandCollider, platformCollider);

        yield return new WaitForSeconds(0.25f);

        Physics2D.IgnoreCollision(StandCollider, platformCollider, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
            CurrentOneWayPlatform = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
            CurrentOneWayPlatform = null;
    }
}
