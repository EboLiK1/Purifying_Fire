using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MenuBase
{
    #region Кнопки
    [Header("Кнопки")]
    [SerializeField] private Button _resume;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _tips;
    [SerializeField] private Button _mainMenu;
    #endregion

    #region Меню
    [Header("Меню")]
    [SerializeField] private GameObject _settingsMenu;
    #endregion

    public override void Awake()
    {
        base.Awake();

        Game.Instance.OnGameUnpaused += Close;

        _resume.onClick.AddListener(() => { Game.Instance.TogglePauseGame(); });
        _settings.onClick.AddListener(() => 
        {
            Close();
            OpenMenu(_settingsMenu); 
        });
        _tips.onClick.AddListener(() => 
        {
            Close();
            OpenMenu(_settingsMenu); 
        });
        _mainMenu.onClick.AddListener(() => { OpenMainMenuScene(); });
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _resume.Select();
    }

    private void Close()
    {
        gameObject.SetActive(false);
        AudioManager.Instance.PlayCloseMenuSound();
    }

    private void OpenMainMenuScene()
    {
        Time.timeScale = 1f;
        SceneSwitcher.Instance.LoadScene(SceneSwitcher.MAIN_MENU);
    }
}