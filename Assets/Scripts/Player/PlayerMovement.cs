using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private Transform playerPos;

    public float PlayerFowardMovementSpeed = 9.95f;

    private float playerBackwardsMovementSpeed;

    [SerializeField] private float playerRotationSpeed = 45f;

    public PlayerActions PlayerActionsScript;

    private float sprintSpeedMultiplier = 1.12f;

    private void Awake()
    {
        playerBackwardsMovementSpeed = PlayerFowardMovementSpeed;
        playerRigidbody = GetComponent<Rigidbody>();
        playerPos = GetComponent<Transform>();
        PlayerActionsScript = GetComponent<PlayerActions>();
    }

    private void FixedUpdate()
    {
        //Apply movement
        if(PlayerActionsScript.CanMove)
        {
            MovePlayer(PlayerActionsScript.PlayerMovementVector.y);
            RotatePlayer(PlayerActionsScript.PlayerMovementVector.x);
        }       
    }

    public void MovePlayer(float direction)
    {
        if (direction > 0.1)
        {
            playerRigidbody.AddForce(transform.forward * PlayerFowardMovementSpeed , ForceMode.Force);
        }
        else if(direction < -0.1)
        {
            playerRigidbody.AddForce(transform.forward * -playerBackwardsMovementSpeed , ForceMode.Force);
        }
        
    }

    public void RotatePlayer(float rotationDirection)
    {
        if (rotationDirection > 0.1)
        {
            transform.Rotate(Vector3.up * (playerRotationSpeed * Time.deltaTime));
        }
        else if(rotationDirection < -0.1)
        {
            transform.Rotate(Vector3.up * (-playerRotationSpeed * Time.deltaTime));
        }
    }

    public void StartPlayerSprintingMomentum() //Called By PlayerActions
    {
        PlayerFowardMovementSpeed *= sprintSpeedMultiplier;
        playerRigidbody.AddForce(transform.forward * PlayerFowardMovementSpeed * 2.1f, ForceMode.Force);
    }

    public void StopPlayerSprintingMomentum() //Called By PlayerActions
    {
        playerRigidbody.AddForce(transform.forward * -PlayerFowardMovementSpeed * 2.5f, ForceMode.Force);
        PlayerFowardMovementSpeed /= sprintSpeedMultiplier;
    }


}
