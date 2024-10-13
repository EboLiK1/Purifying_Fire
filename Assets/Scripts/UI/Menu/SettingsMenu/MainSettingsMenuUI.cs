using UnityEngine;
using UnityEngine.UI;

public class MainSettingsMenuUI : ClosableMenu
{
    #region Кнопки
    [Header("Кнопки")]
    [SerializeField] private Button _game;
    [SerializeField] private Button _video;
    [SerializeField] private Button _sound;
    #endregion

    #region Меню
    [Header("Меню")]
    [SerializeField] private GameObject _gameSettingsMenu;
    [SerializeField] private GameObject _videoSettingsMenu;
    [SerializeField] private GameObject _soundSettingsMenu;
    #endregion

    public override void Awake()
    {
        base.Awake();

        _game.onClick.AddListener(() => { OpenMenu(_gameSettingsMenu); });
        _video.onClick.AddListener(() => { OpenMenu(_videoSettingsMenu); });
        _sound.onClick.AddListener(() => { OpenMenu(_soundSettingsMenu); });
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _game.Select();
    }
}