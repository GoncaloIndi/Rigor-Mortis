using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [HideInInspector] private PlayerMovement playerMovementScript;
    
    [Header("Cameras")]
    [SerializeField] private GameObject currentCamera;
    [SerializeField] private GameObject cameraToActivate;

    private void Awake()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovementScript.IsOnAnotherTrigger++; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerMovementScript.IsOnAnotherTrigger < 2)
            {
                SwitchCameras();
            }
            playerMovementScript.IsOnAnotherTrigger--;
        }
    }

    private void SwitchCameras()
    {
        if (currentCamera.activeSelf)
        {
            cameraToActivate.SetActive(true);
            currentCamera.SetActive(false);

            playerMovementScript.GetCurrentInput();
            playerMovementScript.CameraToUseMovement = cameraToActivate;
            playerMovementScript.IsHoldingMovementCamera = true;
        }
    }
}
