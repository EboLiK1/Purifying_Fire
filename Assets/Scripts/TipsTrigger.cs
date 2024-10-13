using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _tip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Player>() != null)
            if(_tip != null)
                _tip.SetActive(true);
    }
}