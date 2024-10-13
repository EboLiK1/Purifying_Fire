using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Animator _animator;
    private Animator _interactButtonAnimator;

    private string _interactButton;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _interactButtonAnimator = GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        _animator.SetTrigger("Interact");
    }
}