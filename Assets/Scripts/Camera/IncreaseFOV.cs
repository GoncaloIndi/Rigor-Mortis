using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFOV : MonoBehaviour
{
    [SerializeField] private float yOffset; //Determines how much the camera will go up
    [SerializeField] private float zOffset;

    public FollowPlayer CameraFollowScript;
    private bool hasActivatedTrigger = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasActivatedTrigger)
        {
            CameraFollowScript.CameraOffset += new Vector3(0, yOffset, zOffset);
            hasActivatedTrigger = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraFollowScript.CameraOffset -= new Vector3(0, yOffset, zOffset);
            hasActivatedTrigger = false;
        }
        
    }
}
