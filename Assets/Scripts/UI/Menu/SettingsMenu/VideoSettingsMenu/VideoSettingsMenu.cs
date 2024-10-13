using UnityEngine;
using UnityEngine.UI;

public class VideoSettingsMenu : ClosableMenu
{
    #region Кнопки
    [Header("Кнопки")]
    [SerializeField] private Button _resolution;
    [SerializeField] private Button _windowMode;
    [SerializeField] private Button _renderEffects;
    #endregion

    #region Меню
    [Header("Меню")]
    [SerializeField] private GameObject _controllSettingsMenu;
    #endregion

    public override void Awake()
    {
        base.Awake();

        _resolution.onClick.AddListener(() => { SetResolution(); });
        
    }

    private void Start()
    {
        int resolution = PlayerPrefs.GetInt("Resolution");
        _resolution.GetComponent<ToggleMenuButton>()._selectedItemIndex = resolution;
        _resolution.GetComponent<ToggleMenuButton>().UpdateItemLabel();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _resolution.Select();
    }

    private void SetResolution()
    {
        var selector = _resolution.GetComponent<ToggleMenuButton>();
        int resolutionIndex = selector.GetSelectedItemIndex();
        string resolutionString = selector.Items[resolutionIndex];

        string[] resolutionValues = resolutionString.Split('x');
        if (resolutionValues.Length == 2)
        {
            int width = int.Parse(resolutionValues[0]);
            int height = int.Parse(resolutionValues[1]);
            Screen.SetResolution(width, height, true);
            PlayerPrefs.SetInt("Resolution", resolutionIndex);
        }

        AudioManager.Instance.PlayPressButtonSound();
    }
}
