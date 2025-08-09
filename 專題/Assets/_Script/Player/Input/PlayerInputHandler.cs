using UnityEngine;
using UnityEngine.InputSystem;
using Guagua.CoreSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool AttackInput { get; private set; }
    public bool DashInput { get; private set; }

    public Vector2 RawMoveInput { get; private set; }

    [SerializeField] private float inputHoldTime = 0.2f;

    private Core core;
    private SwitchManager switchManager;

    private PlayerInput playerInput;

    private float JumpInputStartime;  //按一下跳得比較低


    private void Awake()
    {
        core = GetComponentInChildren<Core>();
        playerInput = GetComponent<PlayerInput>();

        switchManager = core.GetCoreComponent<SwitchManager>();
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }


    private void HandleGameStateChanged(GameState state)
    {
        /*switch (state)
        {
            case GameState.UI:
                playerInput.SwitchCurrentActionMap("UI");
                break;
            case GameState.Gameplay:
                playerInput.SwitchCurrentActionMap("Gameplay");
                break;
            case GameState.SwitchUI:
                playerInput.SwitchCurrentActionMap("SwitchUI");
                break;
        }*/
    }


    #region GamePlay

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
        }

        if (context.canceled)
        {
            AttackInput = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMoveInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMoveInput.x);
        NormInputY = Mathf.RoundToInt(RawMoveInput.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            JumpInputStartime = Time.time;
        }

        if (context.canceled)   //按一下跳得比較低
        {
            JumpInputStop = true;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
        }

        if (context.canceled)
        {
            DashInput = false;
        }
    }

    public void OnSwitchInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switchManager.HandleSwitchOn();
            GameManager.ChangeState(GameState.SwitchUI);
        }
    }

    #endregion


    #region SwitchUI

    public void OnNextInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switchManager.GoNextPIC();
        }
    }

    public void OnBackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switchManager.GoLastPIC();
        }
    }

    public void OnSwitchDone(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switchManager.HandleSwitchOn();
            GameManager.ChangeState(GameState.Gameplay);
        }
    }


    #endregion


    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= JumpInputStartime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
}
