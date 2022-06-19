using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCombat : MonoBehaviour
{
    [Header("Details")]
    [SerializeField] private RatVFXManager ratVFX;
    [SerializeField] private BloodySword bloodySwordScript;
    [SerializeField] private GameObject shockJumpscareTrigger; //Used for vent rat

    [HideInInspector] public EnemyStats EnemyStatsScript;
    private RatAnimations ratAnimationsScript;
    private RatStateManager ratStateManager;

    private IdleState idleStateScript;

    [Header("Stun Logic")] 
    [SerializeField] private bool canGetStunned = true; //Used to not stagger the rat during certain frames to make combat more risky 
    [SerializeField] private float attackCooldownByStun = 1.6f;
    
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
        //Blood logic 
        ratVFX.BloodVFX();
        bloodySwordScript.UpdateSword();
        
        idleStateScript.HasDetectedPlayer = true;

        if (canGetStunned)
        {
            ratAnimationsScript.DisplayDamageAnimation();
            //prevent the attack if rat is stunned 
            CancelAttack();
            ratStateManager.CurrentAttackCooldown = attackCooldownByStun;
        }

        if (EnemyStatsScript.EnemyHp <= 0) //Damage animation needs to be triggered in order to kill the enemy even if he should not be stunned
        {
            ratAnimationsScript.DisplayDamageAnimation();
            StartCoroutine(KillEnemy());
        }
    }

    private IEnumerator KillEnemy() //Normal Death
    {
        ratStateManager.enabled = false;
        ratStateManager.RatNavMeshAgent.enabled = false;
        ratAnimationsScript.DisplayDeathAnimation();
        yield return new WaitForSeconds(1.2f);
        ratVFX.DustVFX();
        Destroy(this);
    }

    public IEnumerator ElectrifyEnemy() //Called By eletricTrap
    {
        ratStateManager.RatNavMeshAgent.enabled = false;
        ratStateManager.enabled = false;
        EnemyStatsScript.EnemyHp = 0;
        yield return new WaitForSeconds(.1f); //Delay so it is closer to the puddle
        
        CancelAttack();
        
        ratAnimationsScript.DisplayDamageAnimation();
        ratAnimationsScript.DisplayElectrifyAnimation();
        yield return new WaitForSeconds(.2f);
        ratVFX.SmokeVFX();
        if (shockJumpscareTrigger != null) //Setup for jumpscare (VentRat)
        {
            shockJumpscareTrigger.SetActive(true);
        }
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
        var hpStorer = EnemyStatsScript.EnemyHp;
        
        hasAttackSucceded = false;
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.HasPerformedAttack = true;
        ratAnimationsScript.DisplayAttackAnimation(attackTrigger);
        yield return new WaitForSeconds(1.5f);
        canGetStunned = false; //Iframes
        if (EnemyStatsScript.EnemyHp != hpStorer) //Cancel the attack if the rat got hurt
        {
            yield break;
        }
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
        if (ratStateManager.RatNavMeshAgent.isActiveAndEnabled) //Prevent being Called upon death
        {
            ratStateManager.RatNavMeshAgent.SetDestination(transform.position);
        }
        AttackLogic(ratStateManager, lungeAttackRange, lungeAttackPosition);
        canGetStunned = true; //Iframes
    }

    public IEnumerator TailAttack(RatStateManager ratStateManager, string attackTrigger) //Later change Iframes because they are missing antecipation (waiting for new animations)
    {
        hasAttackSucceded = false;
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.HasPerformedAttack = true;
        ratAnimationsScript.DisplayAttackAnimation(attackTrigger);
        canGetStunned = false; //Iframes
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
        canGetStunned = true; //Iframes
    }

    public void CancelAttack()
    {
        StopAllCoroutines();
    }
    
    
}
