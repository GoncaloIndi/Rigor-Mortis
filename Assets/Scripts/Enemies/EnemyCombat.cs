using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodVFX;

    [HideInInspector] public EnemyStats EnemyStatsScript;
    private RatAnimations ratAnimationsScript;
    private RatStateManager ratStateManager;

    private IdleState idleStateScript;

    private void Awake()
    {
        EnemyStatsScript = GetComponent<EnemyStats>();
        idleStateScript = GetComponentInChildren<IdleState>();
        ratAnimationsScript = GetComponent<RatAnimations>();
        ratStateManager = GetComponent<RatStateManager>();
    }

    public void TakeDamage(int damage)
    {
        EnemyStatsScript.EnemyHp -= damage;
        bloodVFX.Play();
        idleStateScript.HasDetectedPlayer = true; //Might need to redo this later
        ratAnimationsScript.DisplayDamageAnimation();
        
        
        if (EnemyStatsScript.EnemyHp <= 0)
        {
            //Code for killing the enemy
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        ratStateManager.enabled = false;
        ratAnimationsScript.DisplayDeathAnimation();
    }

    public IEnumerator ElectrifyEnemy() //Called By eletricTrap
    {
        yield return new WaitForSeconds(.7f); //Delay so it is closer to the puddle
        ratStateManager.enabled = false;
        ratAnimationsScript.DisplayDamageAnimation();
        ratAnimationsScript.DisplayElectrifyAnimation();
    }
    
}
