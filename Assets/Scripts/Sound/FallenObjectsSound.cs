using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObjectsSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glass"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Room_2/sfx_WhiskeyDrop", other.transform.position);
        }
        else if (other.CompareTag("Ball"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Room_2/sfx_BallDrop", other.transform.position);
        }
        else if (other.CompareTag("Trophy"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Room_2/sfx_TrophyDrop", other.transform.position);
        }
    }
}
