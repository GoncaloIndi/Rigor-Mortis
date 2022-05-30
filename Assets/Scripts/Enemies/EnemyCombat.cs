using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private ParticleSystem bloodVFX;
    [SerializeField] private ParticleSystem dustVFX;
    [SerializeField] private ParticleSystem electricVFX;

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
            StartCoroutine(KillEnemy());
        }
    }

    private IEnumerator KillEnemy() //Normal Death
    {
        ratStateManager.enabled = false;
        ratAnimationsScript.DisplayDeathAnimation();
        yield return new WaitForSeconds(1.2f);
        dustVFX.Play();
        Destroy(this);
    }

    public IEnumerator ElectrifyEnemy() //Called By eletricTrap
    {
        EnemyStatsScript.EnemyHp = 0;
        yield return new WaitForSeconds(.3f); //Delay so it is closer to the puddle
        ratStateManager.enabled = false;
        ratAnimationsScript.DisplayDamageAnimation();
        ratAnimationsScript.DisplayElectrifyAnimation();
        yield return new WaitForSeconds(.2f);
        electricVFX.Play();
        Destroy(this);
    }
    
}
