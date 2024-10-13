using System;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public static bool IsFirstGame = true;
    public static string CurrentSceneName;
    public string PreviousSceneName;

    public Action OnGamePaused;
    public Action OnGameUnpaused;
    public Action OnGameOver;

    private bool _isGamePaused = false;

    public GameInput GameInput { get; private set; }
    public PlayerBindings PlayerBindings { get; private set; }
    public AudioManager AudioManager { get; private set; }

    private void Awake()
    {
        GameInput.Game.Pause.started += context => TogglePauseGame();
    }

    [Inject]
    public void Constract(GameInput gameInput)
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        GameInput = gameInput;
    }

    public void TogglePauseGame()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke();
        }
    }

    public void GameOver() =>
        OnGameOver?.Invoke();
}