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

    [SerializeField] private Vector3 cameraPositionReseter;

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
            cameraToActivate.transform.position = cameraPositionReseter;
            cameraToActivate.SetActive(true);
            currentCamera.SetActive(false);

            playerMovementScript.GetCurrentInput();
            playerMovementScript.CameraToUseMovement = cameraToActivate;
            playerMovementScript.IsHoldingMovementCamera = true;
        }
    }
}
