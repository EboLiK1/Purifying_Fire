using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _interactButtonAnimator;

    [SerializeField] private string _sceneName;
    [SerializeField] private TextMeshProUGUI _key;

    private bool _canEnter = false;

    private void Start()
    {
        Game.Instance.GameInput.Player.Interact.started += context => Interact();
        PlayerBindings.Instance.OnViewableBindingRebind += SetText;
        _key.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Interact);
    }

    private void OnDestroy()
    {
        Game.Instance.GameInput.Player.Interact.started -= context => Interact();
    }

    private void Interact()
    {
        if (_canEnter)
            SceneSwitcher.Instance.LoadScene(_sceneName);
    }

    private void SetText() =>
        _key.text = PlayerBindings.Instance.GetBindingText(PlayerBindings.Binding.Interact);

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