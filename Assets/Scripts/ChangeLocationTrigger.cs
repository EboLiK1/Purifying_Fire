using UnityEngine;

public class ChangeLocationTrigger : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Player>() != null)
            SceneSwitcher.Instance.LoadScene(_sceneName);
    }
}
