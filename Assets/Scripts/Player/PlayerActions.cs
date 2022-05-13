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

    private PlayerInputManager playerInputManager;
    

   
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerQuickTurnScript = GetComponent<PlayerQuickTurn>();
        PlayerStatsScript = GetComponent<PlayerStats>();
        PlayerLockOnTargetScript = GetComponent<PlayerLockOnTarget>();
        PlayerAttackScript = GetComponent<PlayerAttack>();
        
        //Player Action Map
        playerInputManager = new PlayerInputManager();
        playerInputManager.Player.Enable();
        playerInputManager.Player.Interact.performed += Interact;
        playerInputManager.Player.Sprint.started += StartSprint;
        playerInputManager.Player.Sprint.canceled += EndSprint;
        playerInputManager.Player.AttackLockOn.started += StartLockOn;
        playerInputManager.Player.AttackLockOn.canceled += StopLockOn;
        playerInputManager.Player.Attack.performed += Attack;
        playerInputManager.Player.QuickTurn.performed += QuickTurn;
        //UI Action Map
        playerInputManager.UI.Accept.performed += Accept;

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
            PlayerMovementScript.ForcePlayerToWalk();
        }
        PlayerLockOnTargetScript.BeginLockOnState();
    }
    
    private void StopLockOn(InputAction.CallbackContext context)
    {
        PlayerLockOnTargetScript.EndLockOnState();

        if (PlayerStatsScript.IsRunning)
        {
            PlayerMovementScript.StartPlayerSprintingMomentum();
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

    //UI Action Map
    private void Accept(InputAction.CallbackContext context)
    {
        Interactible currentItemScript = PlayerStatsScript.CurrentInteractionGameObject.GetComponent<Interactible>();
        currentItemScript.FinishInteract();
    }
    
    //Change Action Maps

    public void PlayerToUI()
    {
        playerInputManager.Player.Disable();
        playerInputManager.UI.Enable();
    }
    
    public void UIToPlayer()
    {
        playerInputManager.UI.Disable();
        playerInputManager.Player.Enable();
    }

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

}
