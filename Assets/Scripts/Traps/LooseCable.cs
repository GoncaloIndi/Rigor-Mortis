using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class LooseCable : MonoBehaviour
{
    
    [HideInInspector]public PlayerStats PlayerStatsScript;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    [SerializeField] private GameObject waterTrap;

    private bool isGettingEletrified = false;

    private void Awake()
    {
        PlayerStatsScript = FindObjectOfType<PlayerStats>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isGettingEletrified = true;
            StartCoroutine(ElectrifyPlayer());
        }
    }

    private void OnTriggerStay(Collider other) //Disable this script whenever the watertrap is enabled
    {
        if (waterTrap.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(ElectrifyPlayer());
        if(other.gameObject.CompareTag("Player"))
        {
            isGettingEletrified = false;
        }
    }

    private IEnumerator ElectrifyPlayer()
    {
        var shockTime = .2f;
        var timesShocked = 0;
        
        while (isGettingEletrified)
        {
            GamePad.SetVibration(playerIndex, 1f, 1f);
            
            
            yield return new WaitForSeconds(shockTime);
            GamePad.SetVibration(playerIndex, 0, 0);
            if (timesShocked < 6)
            {
                timesShocked++;
            }
            else
            {
                TakeShockDamage();
            }
            

            yield return new WaitForSeconds(.5f);
        }
        
    }
    
    private void TakeShockDamage()
    {
        
        PlayerStatsScript.DamagePlayer(10);
    }
}
