using UnityEngine;
using UnityEngine.EventSystems;

public class MenuBase : MonoBehaviour
{
    protected int _currentButtonIndex = 0;

    protected MenuButton[] _buttons;

    protected MenuInputActions MenuInputActions;

    public virtual void Awake()
    {
        _buttons = GetComponentsInChildren<MenuButton>();

        MenuInputActions = new MenuInputActions();

        MenuInputActions.Menu.MoveUp.started += context => MoveUp();
        MenuInputActions.Menu.MoveDown.started += context => MoveDown();
    }

    public virtual void OnEnable()
    {
        _currentButtonIndex = 0;
        MenuInputActions.Menu.Enable();
    }

    public virtual void OnDisable() =>
        MenuInputActions.Menu.Disable();

    public virtual void MoveUp()
    {
        _currentButtonIndex = (_currentButtonIndex - 1 + _buttons.Length) % _buttons.Length;
        SelectButton(_currentButtonIndex);
    }

    public virtual void MoveDown()
    {
        _currentButtonIndex = (_currentButtonIndex + 1) % _buttons.Length;
        SelectButton(_currentButtonIndex);
    }

    public void SelectButton(int index)
    {
        EventSystem.current.SetSelectedGameObject(_buttons[index].gameObject);
        Debug.Log(_buttons[index].gameObject.name);
        AudioManager.Instance.PlayButtonSelectSound();
    }

    public void OpenMenu(GameObject menu)
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
        AudioManager.Instance.PlayPressButtonSound();
    }
}