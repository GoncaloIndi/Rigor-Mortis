using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFOV : MonoBehaviour
{
    [SerializeField] private float yOffset; //Determines how much the camera will go up

    public FollowPlayer CameraFollowScript;

    //Used for fog lerp
    [SerializeField] private float minFogDensity = .08f;
    [SerializeField] private float maxFogDensity = .1f;
    private float lerpTimer;
    private float fogLerpTime = 1;
    private bool fogLerpOrder = false; //True = Max fog to Min fog //False = Min fog to Max fog
    private bool tryToLerp = false;

    private void Awake()
    {
        CameraFollowScript = FindObjectOfType<FollowPlayer>().GetComponent<FollowPlayer>();
        
    }

    private void Update()
    {
        if(!tryToLerp) return;
        
        if (!fogLerpOrder)
        {
            lerpTimer += Time.deltaTime;
            float percentageComplete = lerpTimer / fogLerpTime;
            RenderSettings.fogDensity = Mathf.Lerp(minFogDensity, maxFogDensity , percentageComplete);
        }
        else if (fogLerpOrder)
        {
            lerpTimer += Time.deltaTime;
            float percentageComplete = lerpTimer / fogLerpTime;
            RenderSettings.fogDensity = Mathf.Lerp(maxFogDensity, minFogDensity , percentageComplete);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        CameraFollowScript.CameraOffset += new Vector3(0, yOffset, 0);
        fogLerpOrder = true;
        tryToLerp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        CameraFollowScript.CameraOffset -= new Vector3(0, yOffset, 0);
        fogLerpOrder = false;
        tryToLerp = false;
    }
}
