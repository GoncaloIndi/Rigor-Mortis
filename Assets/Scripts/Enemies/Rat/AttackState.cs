using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackState : State
{
    private ChaseState chaseState;
    [SerializeField] private RatAnimations ratAnimationsScript;
    [SerializeField] private RatStateManager ratStateManagerScript;
    
    [Header("Angle & Distance")]
    [SerializeField] private float minAttackAngle = 160;
    [SerializeField] private float maxAttackAngle = 200;
    [SerializeField] private float minAttackDistance = 1.5f;
    [SerializeField] private float minAttackDistanceOffset = .5f; //In order to make the rat turn and get an angle before getting to close to the player
    [SerializeField] private float maxAttackDistance = 2.5f;
    [SerializeField] private LayerMask ignoreWhenInLineOfSight;
    [SerializeField] private Transform retreatSpot;
    private Vector3 targetDirection;
    private float viewableAngleFromCurrentTarget;

    [Header("Cooldown")]
    [SerializeField] private float currentAttackCooldown;
    [SerializeField] private Transform retreatPosition;
    private bool isGoingBehind = false;

    [Header("Attack Logic")] 
    [SerializeField] private Transform attackPosition;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRange = .3f;
    private bool hasAttackSucceded = false;
 
    private float delayBeforeRetreat;
    private bool isPerformingAttack = false;

    private void Awake()
    {
        chaseState = GetComponent<ChaseState>();
    }

    private void FixedUpdate()
    {
        if (currentAttackCooldown > 0) //Cooldown timer logic (if need be move to ratStateManager)
        {
            currentAttackCooldown -= Time.deltaTime;
            if (currentAttackCooldown <= delayBeforeRetreat) //Retreat a short while after the cooldown so the player has a chance to attack
            {
                Retreat(ratStateManagerScript);
            }
            if (currentAttackCooldown <= 0)
            {
                ratStateManagerScript.HasPerformedAttack = false;
            }
        }
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        GetTargetAngle(ratStateManager);

        

        if (!ratStateManager.HasPerformedAttack && currentAttackCooldown <= 0)
        {
            ValidateAttack(ratStateManager);
        }
        
        if (ratStateManager.ReturnToChaseDistance <= ratStateManager.DistanceFromCurrentTarget && !isPerformingAttack) //Return to chase state
        {
            ratStateManager.HasPerformedAttack = false;
            isGoingBehind = false;
            
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private void ValidateAttack(RatStateManager ratStateManager) //Checks to see if it can attack the player
    {
        if (ratStateManager.DistanceFromCurrentTarget <= maxAttackDistance) //Checks if the player is in attacking distance
        {
            if (ratStateManager.DistanceFromCurrentTarget <= minAttackDistance + minAttackDistanceOffset) //If the rat its too close it gets away from the player until it can attack
            {
                Retreat(ratStateManager);
            }
            
            else if (ratStateManager.DistanceFromCurrentTarget > minAttackDistanceOffset)//Passed distance validations 
            {
                ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
                
                if (viewableAngleFromCurrentTarget <= maxAttackAngle && viewableAngleFromCurrentTarget >= minAttackAngle) //Angle validation
                {
                    //Raycast validation
                    RaycastHit hit;
                    //raycast goes a bit up
                    float height = .2f;
                    var transform1 = ratStateManager.CurrentTarget.transform;
                    Vector3 playerStartPoint = new Vector3(transform1.position.x, transform1.position.y + height, transform1.position.z);
                    var position = transform.position;
                    Vector3 ratStartPoint = new Vector3(position.x, position.y + height, position.z);

                    if (Physics.Linecast(playerStartPoint, ratStartPoint, out hit, ignoreWhenInLineOfSight))
                    {
                        //Improve
                        Retreat(ratStateManager);
                    }
                    else
                    {
                        isGoingBehind = false;
                        StartCoroutine(PerformAttack(ratStateManager));
                    }
                }
                else
                {
                    ratStateManager.RatSpeed = .2f;
                    ratStateManager.ChangeRatSpeed();
                    ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
                }
            }
        }
    }

    private IEnumerator PerformAttack(RatStateManager ratStateManager)
    {
        isPerformingAttack = true;
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.HasPerformedAttack = true;
        ratAnimationsScript.DisplayAttackAnimation();
        yield return new WaitForSeconds(1.5f);
        ratStateManager.RatSpeed = ratStateManager.AttackSpeed;
        ratStateManager.ChangeRatSpeed();
        ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
        yield return new WaitForSeconds(.35f);
        AttackLogic();
        yield return new WaitForSeconds(.3f);
        ratStateManager.RatNavMeshAgent.SetDestination(transform.position);
        AttackLogic();
        currentAttackCooldown = ratStateManager.AttackCooldown;
        isPerformingAttack = false;
        delayBeforeRetreat = Random.Range(0f, .5f);
        delayBeforeRetreat *= ratStateManager.AttackCooldown;
        hasAttackSucceded = false;
    }

    private void GetTargetAngle(RatStateManager ratStateManager)
    {
        targetDirection = ratStateManager.CurrentTarget.transform.position - transform.position;
        viewableAngleFromCurrentTarget = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);
    }

    private void Retreat(RatStateManager ratStateManager)
    {
        if (isGoingBehind) return;

        ratStateManager.RatSpeed = ratStateManager.MaxRatChaseSpeed;
        ratStateManager.ChangeRatSpeed();
        if (!ratStateManager.RatNavMeshAgent.isActiveAndEnabled) return;
        ratStateManager.RatNavMeshAgent.SetDestination(retreatPosition.position);
        isGoingBehind = true;
    }

    private void AttackLogic()
    {
        Collider[] playerCol = Physics.OverlapSphere(attackPosition.position, attackRange, playerLayer);

        if (playerCol.Length < 1 || hasAttackSucceded) return;
            var dmg = Random.Range(6, 11);
            playerCol[0].GetComponent<PlayerStats>().DamagePlayer(dmg, true);
            hasAttackSucceded = true;
    }
}
