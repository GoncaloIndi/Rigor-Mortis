using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFOV : MonoBehaviour
{
    [SerializeField] private float yOffset; //Determines how much the camera will go up

    public FollowPlayer CameraFollowScript;
    private bool hasActivatedTrigger = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasActivatedTrigger)
        {
            CameraFollowScript.CameraOffset += new Vector3(0, yOffset, 0);
            hasActivatedTrigger = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraFollowScript.CameraOffset -= new Vector3(0, yOffset, 0);
            hasActivatedTrigger = false;
        }
        
    }
}
