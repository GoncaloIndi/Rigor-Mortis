using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RatSoundManager : MonoBehaviour
{
    //To better see where sounds are implemented
    public bool ShouldPlayFootSteps;


    private void OnEnable()
    {
        StartCoroutine(RatFootSteps());
    }


    public void RatDamageSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rat/sfx_RatDamage");
    }

    public void RatShockDeathSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rat/sfx_RatDeathShock");
    }

    public void RatIdleSqueak()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rat/sfx_RatDamage", transform.position);
    }

    public void RatTailWhip()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rat/sfx_TailWhip");
    }

    private IEnumerator RatFootSteps() //DefaultFootsteps use RatStateManager.IsInIdleState for the chasing maybe change delay on yields
    {
        
        
        while (true) //Comment relating to animationFrames
        {
            var rng1 = Random.Range(.2f, .4f);
            var rng2 = Random.Range(.36f, .56f);
            
            if (ShouldPlayFootSteps)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rat/sfx_RatFootsteps"); //0
            }
            yield return new WaitForSeconds(rng1); 
            if (ShouldPlayFootSteps)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rat/sfx_RatFootsteps"); //9
            }
            yield return new WaitForSeconds(rng2);//DelayToNextCycle 765 frames
        }
    }
}
