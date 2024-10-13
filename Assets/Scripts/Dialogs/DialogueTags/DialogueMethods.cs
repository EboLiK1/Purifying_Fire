using UnityEngine;
using UnityEngine.Playables;

public class DialogueMethods : MonoBehaviour
{
    [SerializeField] private PlayableDirector _cutscene;

    [SerializeField] private string _sceneName;
    public void ResumeCutscene() => 
        _cutscene.Play();

    public void ChangeScene() =>
        SceneSwitcher.Instance.LoadScene(_sceneName);

    public void CloseDialogWindow() =>
        StartCoroutine(GetComponent<Dialogue>().ExitDialogueMode()); 
}