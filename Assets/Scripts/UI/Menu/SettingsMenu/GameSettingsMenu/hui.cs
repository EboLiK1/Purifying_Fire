using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class hui : ClosableMenu
{
    #region Кнопки управления
    [Header("Кнопки управления")]
    [SerializeField] private Button _moveLeftControl;
    [SerializeField] private Button _moveRightControl;
    [SerializeField] private Button _jumpControl;
    [SerializeField] private Button _crouchControl;
    [SerializeField] private Button _dashControl;
    [SerializeField] private Button _jumpOffControl;
    [SerializeField] private Button _attackControl;
    [SerializeField] private Button _interactControl;
    #endregion

    #region Текст кнопки управления
    [Header("Текст кнопки управления")]
    [SerializeField] private TextMeshProUGUI _moveLeftControlText;
    [SerializeField] private TextMeshProUGUI _MoveRightControlText;
    [SerializeField] private TextMeshProUGUI _jumpControlText;
    [SerializeField] private TextMeshProUGUI _crouchControlText;
    [SerializeField] private TextMeshProUGUI _dashControlText;
    [SerializeField] private TextMeshProUGUI _jumpOffControlText;
    [SerializeField] private TextMeshProUGUI _attackControlText;
    [SerializeField] private TextMeshProUGUI _interactControlText;
    #endregion

    [SerializeField] private GameObject _pressToRebindPanel;

    public RectTransform ScrollRect;
    public RectTransform content;

    public override void Awake()
    {
        base.Awake();

        _moveLeftControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.MoveLeft); });
        _moveRightControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.MoveRight); });
        _jumpControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.Jump); });
        _crouchControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.Crouch); });
        _dashControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.Dash); });
        _jumpOffControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.JumpOffPlatform); });
        _attackControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.Attack); });
        _interactControl.onClick.AddListener(() => { RebindBinding(PlayerBindings.Binding.Interact); });
    }

    private void Start()
    {
        UpdateVisual();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _moveLeftControl.Select();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public void Update()
    {
        ScrollWithSelection(ScrollRect,  content);
    }

    void ScrollWithSelection(RectTransform _scrollRect, RectTransform _content)
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        RectTransform selectedRectTransform = selected.GetComponent<RectTransform>();


        float scrollViewMinY = _content.anchoredPosition.y;
        float scrollViewMaxY = _content.anchoredPosition.y + _scrollRect.rect.height;


        float selectedPositionY = Mathf.Abs(selectedRectTransform.anchoredPosition.y) + (selectedRectTransform.rect.height / 2);

        // If selection below scroll view
        if (selectedPositionY > scrollViewMaxY)
        {
            float newY = selectedPositionY - _scrollRect.rect.height;
            _content.anchoredPosition = new Vector2(_content.anchoredPosition.x, newY);
        }

        // If selection above scroll view
        else if (Mathf.Abs(selectedRectTransform.anchoredPosition.y) < scrollViewMinY)
        {
            _content.anchoredPosition =
                new Vector2(_content.anchoredPosition.x, Mathf.Abs(selectedRectTransform.anchoredPosition.y)
                - (selectedRectTransform.rect.height / 2));
        }
    }

    private void UpdateVisual()
    {
        _moveLeftControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.MoveLeft);
        _MoveRightControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.MoveRight);
        _jumpControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Jump);
        _crouchControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Crouch);
        _dashControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Dash);
        _jumpOffControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.JumpOffPlatform);
        _attackControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Attack);
        _interactControlText.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Interact);
    }

    private void RebindBinding(PlayerBindings.Binding binding)
    {
        ShowPressToRebindKey();

        PlayerBindings.Instance.RebindBinding(binding, () => {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }

    private void ShowPressToRebindKey() =>
        _pressToRebindPanel.SetActive(true);

    private void HidePressToRebindKey() =>
        _pressToRebindPanel.SetActive(false);
}