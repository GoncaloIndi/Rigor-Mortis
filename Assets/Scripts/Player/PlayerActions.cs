using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerInput playerInput;

    [HideInInspector] public Vector2 PlayerMovementVector;

    [HideInInspector] public PlayerMovement PlayerMovementScript;

    [HideInInspector] public PlayerQuickTurn PlayerQuickTurnScript;

    [HideInInspector] public PlayerStats PlayerStatsScript;

    [HideInInspector] public PlayerLockOnTarget PlayerLockOnTargetScript;

    [HideInInspector] public PlayerAttack PlayerAttackScript;

    [HideInInspector] public PauseGame PauseGameScript;

    public PauseMenu PauseMenuScript;

    private PlayerInputManager playerInputManager;
    

   
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerQuickTurnScript = GetComponent<PlayerQuickTurn>();
        PlayerStatsScript = GetComponent<PlayerStats>();
        PlayerLockOnTargetScript = GetComponent<PlayerLockOnTarget>();
        PlayerAttackScript = GetComponent<PlayerAttack>();
        PauseGameScript = FindObjectOfType<PauseGame>();

        //Player Action Map
        playerInputManager = new PlayerInputManager();
        playerInputManager.Player.Enable();
        playerInputManager.Player.Interact.started += Interact;
        playerInputManager.Player.Sprint.started += StartSprint;
        playerInputManager.Player.Sprint.canceled += EndSprint;
        playerInputManager.Player.AttackLockOn.started += StartLockOn;
        playerInputManager.Player.AttackLockOn.canceled += StopLockOn;
        playerInputManager.Player.Attack.started += Attack;
        playerInputManager.Player.QuickTurn.started += QuickTurn;
        playerInputManager.Player.Pause.started += Pause;
        //InteractionUI Action Map
        playerInputManager.InteractionUI.Accept.performed += Accept;
        //PauseMenuUI Action Map
        playerInputManager.PauseMenuUI.Resume.started += Resume;
        playerInputManager.PauseMenuUI.Back.started += Back;

    }

    private void Start()
    {
        if (GameSettings.IsUsingTankControls) return;
            
        PlayerMovementScript.StartPlayerSprintingMomentum(); //For alternate controls to invert sprint mechanics
    }

    private void Update()
    {
        PlayerMovementVector = playerInputManager.Player.Movement.ReadValue<Vector2>();
    }

    
    //Player Action Map
    private void Interact(InputAction.CallbackContext context)
    {
        if (PlayerStatsScript.IsInInteractionZone)
        {
            Interactible currentItemScript = PlayerStatsScript.CurrentInteractionGameObject.GetComponent<Interactible>();
            currentItemScript.Interact();
        }
    }

    private void StartSprint(InputAction.CallbackContext context) //EndSprint in alternate controls
    {
        if (GameSettings.IsUsingTankControls)
        {
            PlayerMovementScript.StartPlayerSprintingMomentum();
        }
        else
        {
            PlayerMovementScript.StopPlayerSprintingMomentum();
        }
        
    }

    private void EndSprint(InputAction.CallbackContext context) //StartSprint in alternate controls
    {
        if (GameSettings.IsUsingTankControls)
        {
            PlayerMovementScript.StopPlayerSprintingMomentum();
        }
        else
        {
            PlayerMovementScript.StartPlayerSprintingMomentum();
        }
        
    }

    private void StartLockOn(InputAction.CallbackContext context)
    {
        if (PlayerStatsScript.IsRunning)
        {
            //PlayerMovementScript.ForcePlayerToWalk();
        }
        //PlayerLockOnTargetScript.BeginLockOnState();
    }
    
    private void StopLockOn(InputAction.CallbackContext context)
    {
        //PlayerLockOnTargetScript.EndLockOnState();

        if (PlayerStatsScript.IsRunning)
        {
            //PlayerMovementScript.StartPlayerSprintingMomentum();
        }

    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (!PlayerStatsScript.HasWeaponEquipped) return;
        PlayerAttackScript.Attack();
    }

    private void QuickTurn(InputAction.CallbackContext context)
    {
        if(PlayerStatsScript.CanMove && PlayerStatsScript.CanRotate && GameSettings.IsUsingTankControls)
        {
            PlayerQuickTurnScript.StartCoroutine(PlayerQuickTurnScript.PerformQuickTurn());
        }
    }

    private void Pause(InputAction.CallbackContext context)
    {
        PauseGameScript.Pause();
    }

    //InteractionUI Action Map
    private void Accept(InputAction.CallbackContext context)
    {
        Interactible currentItemScript = PlayerStatsScript.CurrentInteractionGameObject.GetComponent<Interactible>(); //If the item is caught by default method
        if (currentItemScript != null)
        {
            currentItemScript.FinishInteract();
        }
        else
        {
            InteractionEvent currentEventScript = PlayerStatsScript.CurrentInteractionGameObject.GetComponent<InteractionEvent>(); //If the item is caught by interaction event
            if (currentEventScript != null)
            {
                currentEventScript.FinishInteract();
            }
        }
        
    }
    
    //PauseMenuUI Action Map
    private void Resume(InputAction.CallbackContext context)
    {
        PauseGameScript.Pause();
    }

    private void Back(InputAction.CallbackContext context)
    {
        PauseMenuScript.Back();
    }
    
    //Change Action Maps

    //InteractionUI
    public void PlayerToUI()
    {
        playerInputManager.Player.Disable();
        playerInputManager.InteractionUI.Enable();
    }
    
    public void UIToPlayer()
    {
        playerInputManager.InteractionUI.Disable();
        playerInputManager.Player.Enable();
    }

    //NoInput
    public void PlayerToNoInput()
    {
        if (playerInputManager.NoInput.enabled)
        {
            playerInputManager.NoInput.Disable();
            playerInputManager.Player.Enable();
        }
        else
        {
            playerInputManager.Player.Disable();
            playerInputManager.NoInput.Enable();
        }
    }
    
    //PauseMenuUI
    public void PlayerToPauseMenuUI()
    {
        if (playerInputManager.PauseMenuUI.enabled)
        {
            playerInputManager.PauseMenuUI.Disable();
            playerInputManager.Player.Enable();
        }
        else
        {
            playerInputManager.Player.Disable();
            playerInputManager.PauseMenuUI.Enable();
        }
    }

}
