using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerInput playerInput;

    [HideInInspector] public Vector2 PlayerMovementVector;

    [HideInInspector] public PlayerMovement PlayerMovementScript;

    [HideInInspector] public PlayerQuickTurn PlayerQuickTurnScript;

    private PlayerInputManager playerInputManager;

    public bool CanMove = true;


   
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerQuickTurnScript = GetComponent<PlayerQuickTurn>();

        playerInputManager = new PlayerInputManager();
        playerInputManager.Player.Enable();
        playerInputManager.Player.Interact.performed += Interact;
        playerInputManager.Player.Sprint.started += StartSprint;
        playerInputManager.Player.Sprint.canceled += EndSprint;
        playerInputManager.Player.QuickTurn.performed += QuickTurn;

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
        if(CanMove)
        {
            StartCoroutine(PlayerQuickTurnScript.PerformQuickTurn());
        }
    }

}
