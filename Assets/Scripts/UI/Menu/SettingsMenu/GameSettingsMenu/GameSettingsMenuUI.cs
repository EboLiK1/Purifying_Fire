using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameSettingsMenuUI : ClosableMenu
{
    #region Кнопки
    [Header("Кнопки")]
    [SerializeField] private Button _language;
    [SerializeField] private Button _controlls;
    #endregion

    #region Меню
    [Header("Меню")]
    [SerializeField] private GameObject _controllSettingsMenu;
    #endregion

    public override void Awake()
    {
        base.Awake();

        _language.onClick.AddListener(() => { SetLanguage(); });
        _controlls.onClick.AddListener(() => { OpenMenu(_controllSettingsMenu); });
    }


    public override void OnEnable()
    {
        base.OnEnable();

        _language.Select();
    }

    private void SetLanguage()
    {
        int languageIndex = _language.GetComponent<ToggleMenuButton>().GetSelectedItemIndex();
        string language = LocalizationData.LANGUAGES[languageIndex];
        LocalizationData.CURRENT_LANGUAGE = language;
        LocalizationData.OnLanguageChanged?.Invoke();
        AudioManager.Instance.PlayPressButtonSound();
    }
}