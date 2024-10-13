using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _interactButtonAnimator;

    [SerializeField] private TextAsset _inkJSON_ru;
    [SerializeField] private TextAsset _inkJSON_en;

    [SerializeField] private TextMeshProUGUI _key;

    private bool _canEnter = false;

    private Dialogue _dialogue;
    private DialogueWindow _dialogueWindow;


    private void Start()
    {
        _dialogue = FindObjectOfType<Dialogue>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();

        Game.Instance.GameInput.Player.Interact.started += context => Interact();
        PlayerBindings.Instance.OnViewableBindingRebind += SetText;
        _key.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Interact);
    }

    private void OnDestroy() =>
        Game.Instance.GameInput.Player.Interact.started -= context => Interact();

    private void SetText() =>
        _key.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Interact);

    private void Interact()
    {
        if (_dialogueWindow.IsPlaying == true || _canEnter == false)
            return;

        if (LocalizationData.CURRENT_LANGUAGE == "Русский")
            _dialogue.EnterDialogueMode(_inkJSON_ru);
        else
            _dialogue.EnterDialogueMode(_inkJSON_en);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Player>() != null)
        {
            _interactButtonAnimator.SetBool("IsPlayerClose", true);
            _canEnter = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Player>() != null)
        {
            _interactButtonAnimator.SetBool("IsPlayerClose", false);
            _canEnter = false;
        }
    }
}