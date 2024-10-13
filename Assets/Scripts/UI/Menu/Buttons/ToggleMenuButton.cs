using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleMenuButton : MenuButton
{
    [SerializeField] private TextMeshProUGUI _itemText;

    public string[] Items;

    public int _selectedItemIndex = 0;

    [SerializeField] private bool _isLanguage;
    [SerializeField] private bool _isMusic;
    [SerializeField] private bool _isEffects;
    [SerializeField] private bool _isResolution;
    [SerializeField] private bool _isWindowMode;
    [SerializeField] private bool _isRenderEffects;

    public override void Awake()
    {
        base.Awake();

        if (_isLanguage)
            Items = LocalizationData.LANGUAGES;
        else if (_isMusic || _isEffects)
            Items = new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};  // Создает массив чисел от 1 до 10
        else if(_isResolution)
            Items = new string[] { "1920x1080", "2560x1440", "3840x2160" };
    }

    private void Update()
    {
        GameObject currentlySelected = EventSystem.current.currentSelectedGameObject;

        if (currentlySelected == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                SelectPreviousItem();
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                SelectNextItem();
        }
    }

    private void SelectPreviousItem()
    {
        _selectedItemIndex = (_selectedItemIndex - 1 + Items.Length) % Items.Length;
        AudioManager.Instance.PlayButtonSelectSound();
        UpdateItemLabel();
    }

    private void SelectNextItem()
    {
        _selectedItemIndex = (_selectedItemIndex + 1) % Items.Length;
        AudioManager.Instance.PlayButtonSelectSound();
        UpdateItemLabel();
    }

    public void UpdateItemLabel() =>
        _itemText.text = Items[_selectedItemIndex];

    public int GetSelectedItemIndex() =>
        _selectedItemIndex;
}