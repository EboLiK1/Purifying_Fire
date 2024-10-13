using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private bool _isAnimationOver = false;

    private void Update()
    {
        if (_isAnimationOver)
        {
            if (Input.anyKeyDown)
            {
                SceneSwitcher.Instance.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void AnimationOver() => _isAnimationOver = true;
}