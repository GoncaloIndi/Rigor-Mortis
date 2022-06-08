using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackState : State
{
    private ChaseState chaseState;
    [SerializeField] private RatAnimations ratAnimationsScript;
    [SerializeField] private RatStateManager ratStateManagerScript;
    [SerializeField] private EnemyCombat enemyCombatScript;

    [Header("Zombie Attacks")] 
    [SerializeField] private RatAttackAction[] ratAttackActions;

    [Header("Performable Attacks")] 
    [SerializeField] private List<RatAttackAction> potentialAttacks;

    [Header("Current Attack")] 
    [SerializeField] private RatAttackAction currentAttack;

    [SerializeField] private bool hasAttackSelected; //To improve performance used whenever current attack is being used
    

    [SerializeField] private LayerMask ignoreWhenInLineOfSight;
    private Vector3 targetDirection;
    private float viewableAngleFromCurrentTarget;
    

    private void Awake()
    {
        chaseState = GetComponent<ChaseState>();
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        GetTargetAngle(ratStateManager);


        if (!ratStateManager.HasPerformedAttack && ratStateManager.CurrentAttackCooldown <= 0)
        {
            if (!hasAttackSelected)
            {
                GetValidAttack(ratStateManager);
            }
            else
            {
                AttackTarget(ratStateManager);
            }
        }
        
        if (ratStateManager.CurrentAttackCooldown > 0) //Cooldown timer logic
        {
            ratStateManager.CurrentAttackCooldown -= Time.deltaTime;

            if (ratStateManager.CurrentAttackCooldown <= 0)
            {
                ratStateManagerScript.HasPerformedAttack = false;
            }
        }
        
        if (ratStateManager.ReturnToChaseDistance <= ratStateManager.DistanceFromCurrentTarget) //Return to chase state
        {
            //Reset values
            

            return chaseState;
        }
        else
        {
            return this;
        }
        
        
    }

    private void GetValidAttack(RatStateManager ratStateManager) //See what attack are valid and choose a random one
    {
        for (int i = 0; i < ratAttackActions.Length; i++)
        {
            RatAttackAction ratAttack = ratAttackActions[i];

            //Check for attack distance
            if (ratStateManager.DistanceFromCurrentTarget >= ratAttack.MinAttackDistance
                && ratStateManager.DistanceFromCurrentTarget <= ratAttack.MaxAttackDistance)
            { 
                //Check for attack angles
                print("DistanceCheck");
                if (viewableAngleFromCurrentTarget >= ratAttack.MinAttackAngle
                    && viewableAngleFromCurrentTarget <= ratAttack.MaxAttackAngle)
                {
                    print("AngleCheck");
                    //Add to attack list
                    potentialAttacks.Add(ratAttack);
                }
            }
        }

        int rng = Random.Range(0, potentialAttacks.Count);

        if (potentialAttacks.Count <= 0)
        {
            //Return to chaseState
        }
        else //Choose attack
        {
            currentAttack = potentialAttacks[rng];
            hasAttackSelected = true;
            potentialAttacks.Clear();
        }
    }

    private void AttackTarget(RatStateManager ratStateManager)
    {
        ratStateManager.HasPerformedAttack = true;
        
        if (hasAttackSelected)
        {
            hasAttackSelected = false;

            //Handle logic from different attacks
            if (currentAttack.AttackNumber == 0) //Lunge Attack
            {
                StartCoroutine(enemyCombatScript.PerformLungeAttack(ratStateManager, currentAttack.AttackAnimation));
            }
            else
            {
                ratStateManager.RatSpeed = 0;
                ratStateManager.ChangeRatSpeed();
                ratAnimationsScript.DisplayAttackAnimation(currentAttack.AttackAnimation);
                print("Implement attack logic");
            }
            //Cooldown
            ratStateManager.CurrentAttackCooldown = currentAttack.AttackCooldown;

        }
        else //Should not happer
        {
            Debug.LogWarning("Rat doesnt have attack");
        }
        
        
        
    }

    private void GetTargetAngle(RatStateManager ratStateManager)
    {
        targetDirection = ratStateManager.CurrentTarget.transform.position - transform.position;
        viewableAngleFromCurrentTarget = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);
    }

    private void ResetValues(RatStateManager ratStateManager) //Reset values before going back to chase
    {
        ratStateManager.HasPerformedAttack = false;

        ratStateManager.RatNavMeshAgent.speed = ratStateManager.MinRatChaseSpeed;
        ratStateManager.ChangeRatSpeed();
    }

}
