using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private GameObject cameraOne;
    [SerializeField] private GameObject cameraTwo;

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
