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

        playerInputManager = new PlayerInputManager();
        playerInputManager.Player.Enable();
        playerInputManager.Player.Interact.performed += Interact;
        playerInputManager.Player.Sprint.started += StartSprint;
        playerInputManager.Player.Sprint.canceled += EndSprint;
        playerInputManager.Player.QuickTurn.performed += QuickTurn;
        
        //Starting boost to make movement feel less sluggish    
        playerInputManager.Player.StartingForwardMomentum.performed += StartForwardMomentum;
        playerInputManager.Player.StartingBackwardMomentum.performed += StartBackwardMomentum;

    }

    private void Update()
    {
        PlayerMovementVector = playerInputManager.Player.Movement.ReadValue<Vector2>();
    }


    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interact");
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

}
