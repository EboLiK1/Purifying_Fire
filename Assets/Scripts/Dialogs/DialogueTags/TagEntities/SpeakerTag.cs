using UnityEngine;

public class SpeakerTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        DialogueWindow dialogueWindow = GetComponent<DialogueWindow>();
        dialogueWindow.SetName(value);
    }
}