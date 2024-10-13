using Ink.Runtime;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(DialogueChoice))]
public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayName;
    [SerializeField] private TextMeshProUGUI _displayText;
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private GameObject _continueMessage;
    [SerializeField, Range(0f, 20f)] private float _cooldownNewLetter;

    private string _typeTextSound;

    private DialogueChoice _dialogueChoice;

    public bool IsStatusAnswer { get; private set; }
    public bool IsPlaying { get; private set; }
    public bool CanContinueToNextLine { get; private set; }

    public float CooldownNewLetter
    {
        get => _cooldownNewLetter;
        private set
        {
            if (value < 0f)
                throw new ArgumentException("Значение задержки между буквами было отрицательное");

            _cooldownNewLetter = value;
        }
    }

    //private void OnEnable() =>
    //    Game.Instance.GameInput.Disable();

    //private void OnDisable() =>
    //    Game.Instance.GameInput.Enable();

    public void Init()
    {
        IsStatusAnswer = false;
        CanContinueToNextLine = false;

        _dialogueChoice = GetComponent<DialogueChoice>();
        _dialogueChoice.Init();
    }

    public void SetActive(bool isActive)
    {
        IsPlaying = isActive;
        _dialogueWindow.SetActive(isActive);
    }

    public void SetText(string text) =>
        _displayText.text = text;

    public void Add(string text) =>
        _displayText.text += text;

    public void Add(char letter) =>
        _displayText.text += letter;


    public void ClearText() =>
        _displayText.text = string.Empty;

    public void SetName(string namePerson) =>
        _displayName.text = namePerson;

    public void SetCooldown(float cooldown) =>
        CooldownNewLetter = cooldown;

    public void SetTypeTextSound(string typeTextSound) =>
        _typeTextSound = typeTextSound;

    public void MakeChoice()
    {
        if (!CanContinueToNextLine)
            return;

        IsStatusAnswer = false;
    }

    public IEnumerator DisplayLine(Story story)
    {
        _continueMessage.SetActive(false);
        string line = story.Continue();

        ClearText();

        _dialogueChoice.HideChoices();

        CanContinueToNextLine = false;

        bool isAddingRichText = false;

        yield return new WaitForSeconds(0.001f); // видос говорит, что без этого все летит по пизде

        foreach (char item in line.ToCharArray())
        {
            isAddingRichText = item == '<' || isAddingRichText;

            if (item == '>')
                isAddingRichText = false;

            Add(item);

            if (!isAddingRichText)
            {
                AudioManager.Instance.PlayTypeTextSound(_typeTextSound);
                yield return new WaitForSeconds(_cooldownNewLetter);
            }
        }

        CanContinueToNextLine = true;
        IsStatusAnswer = _dialogueChoice.DisplayChoices(story);

        if(IsStatusAnswer)
            _continueMessage.SetActive(false);
        else
            _continueMessage.SetActive(true);
    }
}
