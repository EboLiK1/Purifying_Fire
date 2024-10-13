using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _deathMenu;

    private void Awake()
    {
        Game.Instance.OnGamePaused += ShowPauseMenu;
        Game.Instance.OnGameOver += ShowDeathMenu;
    }

    private void OnDestroy()
    {
        Game.Instance.OnGamePaused -= ShowPauseMenu;
        Game.Instance.OnGameOver -= ShowDeathMenu;
    }

    public void ShowPauseMenu() =>
        _pauseMenu.SetActive(true);

    public void ShowDeathMenu() =>
        _deathMenu.SetActive(true);
}
