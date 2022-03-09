using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class WaterTrap : MonoBehaviour
{
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private bool isGettingEletrified = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isGettingEletrified = true;
        }
        StartCoroutine(VibrateController());
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(VibrateController());
        if(other.gameObject.CompareTag("Player"))
        {
            isGettingEletrified = false;
        }
    }

    private IEnumerator VibrateController()
    {
        var vibrationTime = .2f;
        while (isGettingEletrified)
        {
            GamePad.SetVibration(playerIndex, 1f, 1f);

            yield return new WaitForSeconds(vibrationTime);
            GamePad.SetVibration(playerIndex, 0, 0);

            yield return new WaitForSeconds(1f);
        }
        
    }
}
