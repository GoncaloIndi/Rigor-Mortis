using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private Transform playerPos;

    [SerializeField] private float playerMovementSpeed = 1.0f;

    [SerializeField] private float playerRotationSpeed = 45f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerPos = GetComponent<Transform>();
    }

    public void MovePlayer(float direction)
    {
        if (direction > 0.1)
        {
            playerRigidbody.AddForce(transform.forward * playerMovementSpeed, ForceMode.Force);
        }
        else if(direction < -0.1)
        {
            playerRigidbody.AddForce(transform.forward * -playerMovementSpeed, ForceMode.Force);
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
}
