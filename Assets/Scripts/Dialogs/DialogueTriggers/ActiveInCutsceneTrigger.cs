using UnityEngine;
using UnityEngine.Playables;

public class ActiveInCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _cutscene;
    [SerializeField] private TextAsset _inkJSON_ru;
    [SerializeField] private TextAsset _inkJSON_en;

    private Dialogue _dialogue;

    private void Start()
    {
        _cutscene.Pause();

        _dialogue = FindObjectOfType<Dialogue>();

        if(LocalizationData.CURRENT_LANGUAGE == "Русский")
            _dialogue.EnterDialogueMode(_inkJSON_ru);
        else
            _dialogue.EnterDialogueMode(_inkJSON_en);
    }
}