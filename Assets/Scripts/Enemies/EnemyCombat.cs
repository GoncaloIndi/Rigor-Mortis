using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodVFX;

    [HideInInspector] public EnemyStats EnemyStatsScript;

    private IdleState idleStateScript;

    private void Awake()
    {
        EnemyStatsScript = GetComponent<EnemyStats>();
        idleStateScript = GetComponentInChildren<IdleState>();
    }

    public void TakeDamage(int damage)
    {
        EnemyStatsScript.EnemyHp -= damage;
        bloodVFX.Play();
        idleStateScript.HasDetectedPlayer = true; //Might need to redo this later
        
        if (EnemyStatsScript.EnemyHp <= 0)
        {
            //Code for killing the enemy
            this.gameObject.SetActive(false);
        }
    }
}
