using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBoxStopper : InteractionEvent
{
    /* This script is responsible for deactivating the
     toyBox climbing prompt and replacing it with an observation 
     whenever the sword is picked up*/

    [SerializeField] private GameObject toyBoxTransition;
    [SerializeField] private GameObject toyBoxObservation;
    private PlayerStats playerStatsScript;

    private void Awake()
    {
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    public override void Trigger()
    {
        if (!playerStatsScript.HasWeaponEquipped) return;
        
        toyBoxTransition.SetActive(false);
        toyBoxObservation.SetActive(true);
    }
}
