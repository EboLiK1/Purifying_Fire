using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslator : MonoBehaviour
{
    [SerializeField] private string _key;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        _text.text = LocalizationData.LOCALIZATION[_key][LocalizationData.CURRENT_LANGUAGE];

        SetText();
        LocalizationData.OnLanguageChanged.AddListener(SetText);
    }

    private void SetText()
    {
        _text.text = LocalizationData.LOCALIZATION[_key][LocalizationData.CURRENT_LANGUAGE];
    }
}