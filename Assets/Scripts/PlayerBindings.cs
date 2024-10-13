using UnityEngine.InputSystem;
using UnityEngine;
using System;
using Zenject;

public class PlayerBindings : MonoBehaviour
{
    public static PlayerBindings Instance { get; private set; }

    private const string PLAYER_PREFS_BINDINGS = "InputBindings";

    public event EventHandler OnBindingRebind;
    public event Action OnViewableBindingRebind;

    public enum Binding
    {
        MoveLeft,
        MoveRight,
        Jump,
        Crouch,
        Dash,
        JumpOffPlatform,
        Attack,
        Interact
    }

    public GameInput GameInput { get; private set; }

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //    Destroy(gameObject);

        //GameInput = new GameInput();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
            GameInput.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
    }

    [Inject]
    public void Initialize(GameInput inputs)
    {
        Instance = this;

        GameInput = inputs;
    }

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.MoveLeft:
                return GameInput.Player.Move.bindings[1].ToDisplayString();
            case Binding.MoveRight:
                return GameInput.Player.Move.bindings[2].ToDisplayString();
            case Binding.Jump:
                return GameInput.Player.Jump.bindings[0].ToDisplayString();
            case Binding.Crouch:
                return GameInput.Player.Crouch.bindings[0].ToDisplayString();
            case Binding.Dash:
                return GameInput.Player.Dash.bindings[0].ToDisplayString();
            case Binding.JumpOffPlatform:
                return GameInput.Player.JumpOffPlatform.bindings[0].ToDisplayString();
            case Binding.Attack:
                return GameInput.Player.Attack.bindings[0].ToDisplayString();
            case Binding.Interact:
                return GameInput.Player.Interact.bindings[0].ToDisplayString();
        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound)
    {
        GameInput.Player.Disable();

        InputAction inputAction;
        int bindingIndex;

        switch (binding)
        {
            default:
            case Binding.MoveLeft:
                inputAction = GameInput.Player.Move;
                bindingIndex = 1;
                break;
            case Binding.MoveRight:
                inputAction = GameInput.Player.Move;
                bindingIndex = 2;
                break;
            case Binding.Dash:
                inputAction = GameInput.Player.Dash;
                bindingIndex = 0;
                break;
            case Binding.Crouch:
                inputAction = GameInput.Player.Crouch;
                bindingIndex = 0;
                break;
            case Binding.Jump:
                inputAction = GameInput.Player.Jump;
                bindingIndex = 0;
                break;
            case Binding.JumpOffPlatform:
                inputAction = GameInput.Player.JumpOffPlatform;
                bindingIndex = 0;
                break;
            case Binding.Attack:
                inputAction = GameInput.Player.Attack;
                bindingIndex = 0;
                break;
            case Binding.Interact:
                inputAction = GameInput.Player.Interact;
                bindingIndex = 0;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex).OnComplete(callback =>
        {
            callback.Dispose();
            GameInput.Player.Enable();
            onActionRebound();

            PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, GameInput.SaveBindingOverridesAsJson());
            PlayerPrefs.Save();

            OnBindingRebind?.Invoke(this, EventArgs.Empty);

            if (binding == Binding.Interact)
                OnViewableBindingRebind?.Invoke();
        })
            .Start();
    }
}