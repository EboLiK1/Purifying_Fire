using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] protected Color _selectedColor;
    [SerializeField] protected Color _deselectedColor;
    [SerializeField] protected bool _isFirstSelected;

    private TextMeshProUGUI[] _buttonTexts;

    public virtual void Awake() =>
        _buttonTexts = GetComponentsInChildren<TextMeshProUGUI>();

    public void OnEnable()
    {
        if (_isFirstSelected)
            ChangeTextColor(_selectedColor);
        else
            ChangeTextColor(_deselectedColor);
    }

    public void OnSelect(BaseEventData eventData) =>
        ChangeTextColor(_selectedColor);

    public void OnDeselect(BaseEventData eventData) =>
        ChangeTextColor(_deselectedColor);

    protected void ChangeTextColor(Color color)
    {
        foreach (TextMeshProUGUI buttonText in _buttonTexts)
            buttonText.color = color;
    }
}
