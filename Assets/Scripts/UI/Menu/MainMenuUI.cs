using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MenuBase
{
    #region Кнопки
    [Header("Кнопки")]
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _aboutGame;
    [SerializeField] private Button _quit;
    #endregion

    #region Меню
    [Header("Меню")]
    [SerializeField] private GameObject _mainSettingsMenu;
    [SerializeField] private GameObject _aboutGameMenu;
    #endregion

    public override void Awake()
    {
        base.Awake();

        _play.onClick.AddListener(() => { SceneSwitcher.Instance.LoadScene("Intro"); });
        _settings.onClick.AddListener(() => { OpenMenu(_mainSettingsMenu); });
        _aboutGame.onClick.AddListener(() => { OpenMenu(_aboutGameMenu); });
        _quit.onClick.AddListener(() => { Application.Quit(); });
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _play.Select();
    }
}