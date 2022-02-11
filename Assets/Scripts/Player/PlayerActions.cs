using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerInput playerInput;

    private Vector2 playerMovementVector;

    [HideInInspector] public PlayerMovement PlayerMovementScript;

    private PlayerInputManager playerInputManager;
    
    



    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();

        playerInputManager = new PlayerInputManager();
        playerInputManager.Player.Enable();
        playerInputManager.Player.Interact.performed += Interact;

    }

    private void Update()
    {
        playerMovementVector = playerInputManager.Player.Movement.ReadValue<Vector2>();
        
        //Apply movement
        PlayerMovementScript.MovePlayer(playerMovementVector.y);
        PlayerMovementScript.RotatePlayer(playerMovementVector.x);
    }


    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interact");
    }

}
