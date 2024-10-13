using UnityEngine;

public class ClosableMenu : MenuBase
{
    [SerializeField] private GameObject _previousMenu;

    public override void Awake()
    {
        base.Awake();

        MenuInputActions.Menu.Close.started += context => Close();
    }

    protected void Close()
    {
        gameObject.SetActive(false);
        _previousMenu.SetActive(true);
        AudioManager.Instance.PlayCloseMenuSound();
    }
}