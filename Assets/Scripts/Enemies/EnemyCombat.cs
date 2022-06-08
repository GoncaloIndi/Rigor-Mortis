using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    
    [Header("Attack Logic")] 
    [SerializeField] private Transform lungeAttackPosition;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float lungeAttackRange = .27f;
    private bool hasAttackSucceded = false;
    //TailAttacks
    [SerializeField] private float tailAttackRange = .45f;
    [SerializeField] private Transform tailAttackPosition;
    

    private void Awake()
    {
        EnemyStatsScript = GetComponent<EnemyStats>();
        idleStateScript = GetComponentInChildren<IdleState>();
        ratAnimationsScript = GetComponent<RatAnimations>();
        ratStateManager = GetComponent<RatStateManager>();
    }

    //When rat is hurt
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
        ratStateManager.RatNavMeshAgent.enabled = false;
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
        ratStateManager.RatNavMeshAgent.enabled = false;
        ratAnimationsScript.DisplayDamageAnimation();
        ratAnimationsScript.DisplayElectrifyAnimation();
        yield return new WaitForSeconds(.2f);
        electricVFX.Play();
        Destroy(this);
    }
    
    //Rat attack logic
    
    private void AttackLogic(RatStateManager ratStateManager, float attackRange, Transform attackPostion) //Logic for hurting player
    {
            Collider[] playerCol = Physics.OverlapSphere(attackPostion.position, attackRange, playerLayer);
    
            if (playerCol.Length < 1 || hasAttackSucceded) return;
                var dmg = Random.Range(6, 11);
                playerCol[0].GetComponent<PlayerStats>().DamagePlayer(dmg, true);
                ratStateManager.RatSpeed = 0;
                ratStateManager.ChangeRatSpeed();
                hasAttackSucceded = true;
    }
    
    public IEnumerator PerformLungeAttack(RatStateManager ratStateManager, string attackTrigger) //Lunge attack Logic
    {
        hasAttackSucceded = false;
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.HasPerformedAttack = true;
        ratAnimationsScript.DisplayAttackAnimation(attackTrigger);
        yield return new WaitForSeconds(1.5f);
        ratStateManager.RatSpeed = ratStateManager.AttackSpeed;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
        yield return new WaitForSeconds(.1f);
        AttackLogic(ratStateManager, lungeAttackRange, lungeAttackPosition);
        yield return new WaitForSeconds(.1f);
        AttackLogic(ratStateManager, lungeAttackRange, lungeAttackPosition);
        yield return new WaitForSeconds(.15f);
        AttackLogic(ratStateManager, lungeAttackRange, lungeAttackPosition);
        yield return new WaitForSeconds(.3f);
        ratStateManager.RatNavMeshAgent.SetDestination(transform.position);
        AttackLogic(ratStateManager, lungeAttackRange, lungeAttackPosition);
    }

    public IEnumerator TailAttack(RatStateManager ratStateManager, string attackTrigger)
    {
        hasAttackSucceded = false;
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.HasPerformedAttack = true;
        ratAnimationsScript.DisplayAttackAnimation(attackTrigger);
        yield return new WaitForSeconds(.35f);
        AttackLogic(ratStateManager, tailAttackRange, tailAttackPosition);
        yield return new WaitForSeconds(.2f);
        AttackLogic(ratStateManager, tailAttackRange, tailAttackPosition);
        yield return new WaitForSeconds(.2f);
        AttackLogic(ratStateManager, tailAttackRange, tailAttackPosition);
        yield return new WaitForSeconds(.2f);
        AttackLogic(ratStateManager, tailAttackRange, tailAttackPosition);
        yield return new WaitForSeconds(.2f);
        AttackLogic(ratStateManager, tailAttackRange, tailAttackPosition);
        
        
    }
    
    
}
