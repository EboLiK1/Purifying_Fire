using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] _choices;

    private TextMeshProUGUI[] _choicesText;

    public void Init()
    {
        _choicesText = new TextMeshProUGUI[_choices.Length];

        int index = 0;
        foreach (GameObject item in _choices)
        {
            _choicesText[index++] = item.GetComponentInChildren<TextMeshProUGUI>();
        }


    }

    public bool DisplayChoices(Story story)
    {
        Choice[] currentChoices = story.currentChoices.ToArray();

        if(currentChoices.Length > _choices.Length )
            throw new ArgumentNullException("Выборов в сценарии больше, чем возможностей в игре!");

        HideChoices();

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            _choices[index].SetActive(true);
            _choicesText[index++].text = choice.text;
        }

        return currentChoices.Length > 0;
    }

    public void HideChoices() =>
        Array.ForEach(_choices, button => { button.SetActive(false); });
}
