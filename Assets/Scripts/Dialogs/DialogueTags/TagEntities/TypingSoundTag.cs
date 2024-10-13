using UnityEngine;

public class TypingSoundTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        DialogueWindow dialogueWindow = GetComponent<DialogueWindow>();
        dialogueWindow.SetTypeTextSound(value);
    }
}