using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [HideInInspector] private PlayerMovement playerMovementScript;
    
    [Header("Cameras")]
    [SerializeField] private GameObject cameraOne;
    [SerializeField] private GameObject cameraTwo;

    private void Awake()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwitchCameras();
        }
    }

    private void SwitchCameras()
    {
        if (cameraOne.activeSelf)
        {
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);
        }
        else
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
        }
    }
}
