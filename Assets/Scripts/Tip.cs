using UnityEngine;

public class Tip : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Game.Instance.GameInput.Disable();

    }

    private void OnDisable()
    {
        Game.Instance.GameInput.Enable();
        Destroy(gameObject);
    }
}
