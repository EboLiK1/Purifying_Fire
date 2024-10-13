using UnityEngine;

public class Localization : MonoBehaviour
{
    public static Localization Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        int localizationId = PlayerPrefs.GetInt("LocaleKey", 0);
        SetSelectedLocale(localizationId);
    }

    private void SetSelectedLocale(int localeId)
    {

    }
}
