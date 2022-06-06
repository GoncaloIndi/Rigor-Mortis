using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerAnimations playerAnimationsScript;
    [SerializeField] private float walkFootstepDelay, runFootstepDelay;
    private float elapsedTime = 0;

    private void Awake()
    {
        playerAnimationsScript = GetComponentInParent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
    }


    public void PlayFootstep() //Glitchy so works with playerAnimations and failSafes
    {
        if (playerAnimationsScript.AnimationState == 0) return;

        if (playerAnimationsScript.AnimationState == 1 && elapsedTime >= walkFootstepDelay)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/sfx_Footsteps");
            elapsedTime = 0;
        }
        else if (playerAnimationsScript.AnimationState == 2 && elapsedTime >= runFootstepDelay)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/sfx_Footsteps");
            elapsedTime = 0;
        }
        
    }
}
