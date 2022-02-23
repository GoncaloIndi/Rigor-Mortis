using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerInput playerInput;

    [HideInInspector] public Vector2 PlayerMovementVector;

    [HideInInspector] public PlayerMovement PlayerMovementScript;

    [HideInInspector] public PlayerQuickTurn PlayerQuickTurnScript;

    [HideInInspector] public PlayerStats PlayerStatsScript;

    private PlayerInputManager playerInputManager;
    

   
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerQuickTurnScript = GetComponent<PlayerQuickTurn>();
        PlayerStatsScript = GetComponent<PlayerStats>();
        
        //Player Action Map
        playerInputManager = new PlayerInputManager();
        playerInputManager.Player.Enable();
        playerInputManager.Player.Interact.performed += Interact;
        playerInputManager.Player.Sprint.started += StartSprint;
        playerInputManager.Player.Sprint.canceled += EndSprint;
        playerInputManager.Player.QuickTurn.performed += QuickTurn;
        //UI Action Map
        playerInputManager.UI.Accept.performed += Accept;
        
        //Starting boost to make movement feel less sluggish    
        playerInputManager.Player.StartingForwardMomentum.performed += StartForwardMomentum;
        playerInputManager.Player.StartingBackwardMomentum.performed += StartBackwardMomentum;

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
            Item currentItemScript = PlayerStatsScript.CurrentInteractionGameObject.GetComponent<Item>();
            currentItemScript.Interact();
        }
    }

    private void StartSprint(InputAction.CallbackContext context)
    {
        PlayerMovementScript.StartPlayerSprintingMomentum();
    }

    private void EndSprint(InputAction.CallbackContext context)
    {
        PlayerMovementScript.StopPlayerSprintingMomentum();
    }

    private void QuickTurn(InputAction.CallbackContext context)
    {
        if(PlayerStatsScript.CanMove)
        {
            PlayerQuickTurnScript.StartCoroutine(PlayerQuickTurnScript.PerformQuickTurn());
        }
    }

    private void StartForwardMomentum(InputAction.CallbackContext context)
    {
        PlayerMovementScript.ApplyJumpStartingMomentum(true);
    }
    
    private void StartBackwardMomentum(InputAction.CallbackContext context)
    {
        PlayerMovementScript.ApplyJumpStartingMomentum(false);
    }

    //UI Action Map
    private void Accept(InputAction.CallbackContext context)
    {
        Item currentItemScript = PlayerStatsScript.CurrentInteractionGameObject.GetComponent<Item>();
        currentItemScript.FinishInteract();
    }
    
    //Change Action Maps

    public void PlayerToUI()
    {
        //playerInput.SwitchCurrentActionMap("UI");
        playerInputManager.Player.Disable();
        playerInputManager.UI.Enable();
    }
    
    public void UIToPlayer()
    {
        playerInputManager.UI.Disable();
        playerInputManager.Player.Enable();
    }

}
