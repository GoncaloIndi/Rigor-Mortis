using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class KillerFootsteps : MonoBehaviour
{
    [SerializeField] private Transform killerPosition;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartFootsteps());
        }
    }

    private IEnumerator StartFootsteps()
    {
        for (int i = 0; i < 5; i++)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/sfx_KillerFootsteps", killerPosition.position);
            GamePad.SetVibration(playerIndex, .8f, .8f);
            yield return new WaitForSeconds(.2f);
            GamePad.SetVibration(playerIndex, 0, 0);
            yield return new WaitForSeconds(.5f);
        }
        this.gameObject.SetActive(false);
    }
}
