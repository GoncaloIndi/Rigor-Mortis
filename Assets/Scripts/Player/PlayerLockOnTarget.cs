using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockOnTarget : MonoBehaviour
{
    public PlayerStats PlayerStatsScript;

    private void Awake()
    {
        PlayerStatsScript = GetComponent<PlayerStats>();
    }

    public void BeginLockOnState()
    {
        PlayerStatsScript.IsOnTargetLockOn = true;
        PlayerStatsScript.CanMove = false;
    }

    

    public void EndLockOnState()
    {
        PlayerStatsScript.IsOnTargetLockOn = false;
        PlayerStatsScript.CanMove = true;
    }
}
