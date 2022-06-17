using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackState : State
{
    private ChaseState chaseState;
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

    //Rotate towards player
    private Quaternion rotationDirection;
    private float rotationTime = 0;
    private bool resetRotationTimer = true;
    
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
        
        if (ratStateManager.ReturnToChaseDistance <= ratStateManager.DistanceFromCurrentTarget && !ratStateManager.HasPerformedAttack) //Return to chase state
        {
            //Reset values
            
            ResetValues(ratStateManager);

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
                if (viewableAngleFromCurrentTarget >= ratAttack.MinAttackAngle
                    && viewableAngleFromCurrentTarget <= ratAttack.MaxAttackAngle)
                {
                    //Add to attack list
                    potentialAttacks.Add(ratAttack);
                }
            }
        }

        int rng = Random.Range(0, potentialAttacks.Count);

        if (potentialAttacks.Count <= 0) //If has no attacks
        {
            //Rotate towardsPlayer
            if (resetRotationTimer)
            {
                resetRotationTimer = false;
                rotationTime = 0;
            }
            rotationTime += Time.deltaTime;
            UpdateTargetPosition();
            ratStateManager.transform.rotation = Quaternion.Slerp(ratStateManager.transform.rotation, rotationDirection, rotationTime * Time.deltaTime / .1f);
        }
        else //Choose attack
        {
            resetRotationTimer = true;
            currentAttack = potentialAttacks[rng];
            hasAttackSelected = true;
            potentialAttacks.Clear();
        }
    }

    private void AttackTarget(RatStateManager ratStateManager) //Perform the attack chosen
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
                StartCoroutine(enemyCombatScript.TailAttack(ratStateManager, currentAttack.AttackAnimation));
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

    // Rotate rat until he gets back into a valid attack position
    
    private void UpdateTargetPosition()
    {
        Vector3 lockOnVector = ratStateManagerScript.CurrentTarget.transform.position - transform.position;
        rotationDirection = Quaternion.LookRotation(lockOnVector);
        rotationDirection = ClampQuaternionValues(rotationDirection);
    }
    
    Quaternion ClampQuaternionValues(Quaternion q) //Look mom I'm a wizard I made quaternion math
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
  
        //Clamp X
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
        angleX = Mathf.Clamp (angleX, 0, 0);
        q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
        
        //Clamp Z
        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.z);
        angleZ = Mathf.Clamp (angleZ, 0, 0);
        q.z = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleZ);

        return q;
    }

}
