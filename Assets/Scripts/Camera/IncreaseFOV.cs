using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFOV : MonoBehaviour
{
    [SerializeField] private float yOffset; //Determines how much the camera will go up

    public FollowPlayer CameraFollowScript;
    

    private void Awake()
    {
        CameraFollowScript = FindObjectOfType<FollowPlayer>().GetComponent<FollowPlayer>();
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        CameraFollowScript.CameraOffset += new Vector3(0, yOffset, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        CameraFollowScript.CameraOffset -= new Vector3(0, yOffset, 0);
    }
}
