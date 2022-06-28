using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOutlets : Damageable
{
    private PlayerStats playerStatsScript;

    private void Awake()
    {
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    public override void OnDamage()
    {
        base.OnDamage();
        playerStatsScript.DamagePlayer(3, true);
    }
}
