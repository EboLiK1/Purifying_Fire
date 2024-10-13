using Ink.Runtime;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;
    [SerializeField] private Dialogue _dialogue;

    public void ChangeField(int value)
    {
        Story story = new Story(_inkJSON.text);

        story.variablesState["nameField"] = value;
        
        Debug.Log(story.variablesState["nameField"]);
    }
}