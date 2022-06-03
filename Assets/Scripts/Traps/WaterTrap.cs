using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using XInputDotNetPure;


public class WaterTrap : MonoBehaviour
{

    [HideInInspector]public PlayerStats PlayerStatsScript;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private bool isGettingEletrified = false;
    private bool hasKilledRat = false;

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
        else if (other.gameObject.CompareTag("Enemy")) //Make it so that when the rat hits the the trap and has no target (idle state only) it returns to its origin point instead of dying
        {
            RatStateManager ratState = other.gameObject.GetComponent<RatStateManager>();
            if (ratState.CurrentTarget == null)
            {
                ratState.ReturnToOrigin = true;
            }
            else
            {
                EnemyCombat enemy = other.gameObject.GetComponent<EnemyCombat>();
                if (enemy != null)
                {
                    hasKilledRat = true;
                    StartCoroutine(enemy.ElectrifyEnemy());
                }
            }
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !hasKilledRat) 
        {
            RatStateManager ratState = other.gameObject.GetComponent<RatStateManager>();
            if (ratState.CurrentTarget == null)
            {
                ratState.ReturnToOrigin = true;
            }
            else
            {
                EnemyCombat enemy = other.gameObject.GetComponent<EnemyCombat>();
                if (enemy != null)
                {
                    hasKilledRat = true;
                    StartCoroutine(enemy.ElectrifyEnemy());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(ElectrifyPlayer());
        if(other.gameObject.CompareTag("Player"))
        {
            isGettingEletrified = false;
            GamePad.SetVibration(playerIndex, 0, 0); //Prevent infinite vibration
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
            if (timesShocked < 3)
            {
                timesShocked++;
            }
            else
            {
                TakeShockDamage();
            }
            

            yield return new WaitForSeconds(1f);
        }
        
    }
    
    private void TakeShockDamage()
    {
        PlayerStatsScript.DamagePlayer(10, false);
    }
}
