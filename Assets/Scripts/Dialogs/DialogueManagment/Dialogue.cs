using Ink.Runtime;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DialogueWindow))]
[RequireComponent(typeof(DialogueTag))]
public class Dialogue : MonoBehaviour
{
    private DialogueWindow _dialogueWindow;
    private DialogueTag _dialogueTag;

    public Story CurrentStory { get; private set; }

    private Coroutine _displayLineCoroutine;
    DialogInputAction inputActions;

    private void Awake()
    {
        _dialogueWindow = GetComponent<DialogueWindow>();
        _dialogueTag = GetComponent<DialogueTag>();

        _dialogueWindow.Init();
        _dialogueTag.Init();

        inputActions = new DialogInputAction();

        inputActions.Dialogue.ContinueStory.started += context => NextStory();
    }

    private void Start()
    {
        _dialogueWindow.SetActive(false);
    }

    private void Update()
    {
        if (_dialogueWindow.IsStatusAnswer == true || _dialogueWindow.IsPlaying == false || _dialogueWindow.CanContinueToNextLine == false)
            return;

        if (Input.GetKeyDown(KeyCode.F))
            ContinueStory();
    }

    private void NextStory()
    {
        if (_dialogueWindow.IsStatusAnswer == true || _dialogueWindow.IsPlaying == false || _dialogueWindow.CanContinueToNextLine == false)
            return;

        ContinueStory();
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Game.Instance.GameInput.Disable();
        CurrentStory = new Story(inkJSON.text);

        _dialogueWindow.SetActive(true);

        ContinueStory();
    }

    public IEnumerator ExitDialogueMode() 
    {
        yield return new WaitForSeconds(_dialogueWindow.CooldownNewLetter);
        Game.Instance.GameInput.Enable();
        _dialogueWindow.SetActive(false);
        _dialogueWindow.ClearText();
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue == false)
        {
            StartCoroutine(ExitDialogueMode());
            return;
        }

        _displayLineCoroutine = StartCoroutine(_dialogueWindow.DisplayLine(CurrentStory));

        try
        {
            _dialogueTag.HandleTags(CurrentStory.currentTags);
        }
        catch (ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        _dialogueWindow.MakeChoice();

        CurrentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }
}
