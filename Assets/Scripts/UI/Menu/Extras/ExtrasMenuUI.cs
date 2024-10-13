using UnityEngine;
using UnityEngine.UI;

public class ExtrasMenuUI : ClosableMenu
{
    #region Кнопки
    [Header("Кнопки")]
    [SerializeField] private Button _aboutGame;
    [SerializeField] private Button _titles;
    #endregion

    #region Меню
    [Header("Меню")]
    [SerializeField] private GameObject _aboutGameMenu;
    #endregion

    public override void Awake()
    {
        base.Awake();

        _aboutGame.onClick.AddListener(() => { OpenMenu(_aboutGameMenu); });
        _titles.onClick.AddListener(() => { SceneSwitcher.Instance.LoadScene("Title"); });
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _aboutGame.Select();
    }
}