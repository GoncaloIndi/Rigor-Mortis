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

    private InventoryManager inventoryManagerScript;

    private InventoryUseItem inventoryUseItemScript;
    

   
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inventoryManagerScript = FindObjectOfType<InventoryManager>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerQuickTurnScript = GetComponent<PlayerQuickTurn>();
        PlayerStatsScript = GetComponent<PlayerStats>();
        PlayerLockOnTargetScript = GetComponent<PlayerLockOnTarget>();
        PlayerAttackScript = GetComponent<PlayerAttack>();
        PauseGameScript = FindObjectOfType<PauseGame>();
        inventoryUseItemScript = FindObjectOfType<InventoryUseItem>();

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
        playerInputManager.Player.Inventory.started += OpenInventory;
        //InteractionUI Action Map
        playerInputManager.InteractionUI.Accept.performed += Accept;
        //NoInputActionMap
        playerInputManager.NoInput.Pause.started += PauseFromNoInput;
        //PauseMenuUI Action Map
        playerInputManager.PauseMenuUI.Resume.started += Resume;
        playerInputManager.PauseMenuUI.Back.started += Back;
        //InventoryActionMap
        playerInputManager.Inventory.Resume.started += CloseInventory;
        playerInputManager.Inventory.Back.started += BackInventory;
        playerInputManager.Inventory.NextTab.started += NextTab;
        playerInputManager.Inventory.PreviousTab.started += PreviousTab;
        playerInputManager.Inventory.NextItem.started += NextItem;
        playerInputManager.Inventory.NextItem.canceled += NextItemRelease;
        playerInputManager.Inventory.PreviousItem.started += PreviousItem;
        playerInputManager.Inventory.PreviousItem.canceled += PreviousItemRelease;
        playerInputManager.Inventory.Use.started += UseItem;


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
        PauseGameScript.Pause(false);
    }

    private void OpenInventory(InputAction.CallbackContext context)
    {
        inventoryManagerScript.OpenInventory();
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
    
    //NoInput ActionMap
    private void PauseFromNoInput(InputAction.CallbackContext context)
    {
        PauseGameScript.Pause(true);
    }
    
    //PauseMenuUI Action Map
    private void Resume(InputAction.CallbackContext context)
    {
        PauseGameScript.Pause(false);
    }

    private void Back(InputAction.CallbackContext context)
    {
        PauseMenuScript.Back();
    }
    
    //Inventory Action Map
    
    private void CloseInventory(InputAction.CallbackContext context)
    {
        inventoryManagerScript.CloseInventory();
    }
    
    private void BackInventory(InputAction.CallbackContext context)
    {
        inventoryManagerScript.BackInventory();
    }

    private void NextTab(InputAction.CallbackContext context)
    {
        inventoryManagerScript.NextTab();
    }
    
    private void PreviousTab(InputAction.CallbackContext context)
    {
        inventoryManagerScript.PreviousTab();
    }

    private void NextItem(InputAction.CallbackContext context)
    {
        inventoryManagerScript.NextItem();
    }

    private void NextItemRelease(InputAction.CallbackContext context)
    {
        inventoryManagerScript.OnNextItemRelease();
    }
    
    private void PreviousItem(InputAction.CallbackContext context)
    {
        inventoryManagerScript.PreviousItem();
    }

    private void PreviousItemRelease(InputAction.CallbackContext context)
    {
        inventoryManagerScript.OnPreviousItemRelease();
    }

    private void UseItem(InputAction.CallbackContext context)
    {
        inventoryUseItemScript.UseItem();
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
    public void PlayerToNoInput(bool toggle)
    {
        if (!toggle)
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
    
    public void PauseToNoInput(bool toggle)
    {
        if (!toggle)
        {
            playerInputManager.NoInput.Disable();
            playerInputManager.PauseMenuUI.Enable();
        }
        else
        {
            playerInputManager.PauseMenuUI.Disable();
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
    
    //Inventory
    public void PlayerToInventory(bool toggle)
    {
        if (!toggle)
        {
            playerInputManager.Inventory.Disable();
            playerInputManager.Player.Enable();
        }
        else
        {
            playerInputManager.Player.Disable();
            playerInputManager.Inventory.Enable();
        }
    }

}
