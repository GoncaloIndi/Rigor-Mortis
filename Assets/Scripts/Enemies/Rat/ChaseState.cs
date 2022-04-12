using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    //Chase the player until he is no longer in sight (Retreat)
    //or start attacking when he is in range (Attack)

    private AttackState attackState;
    private IdleState idleState;
    private bool hasPlayerInSight = true;
    private Vector3 currentDestination;
    
    //Raycast to see if the player is still in line of sight
    [SerializeField] private LayerMask ignoreWhenInLineOfSight;

    private void Awake()
    {
        attackState = GetComponent<AttackState>();
        idleState = GetComponent<IdleState>();
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        if (ratStateManager.IsPerformingAction) 
        {
            return this;
        }
        
        MoveTowardsCurrentTarget(ratStateManager);
        
        if (ratStateManager.DistanceFromCurrentTarget <= ratStateManager.MinimumAttackDistance && hasPlayerInSight) //Transition to AttackState
        {
            //Raycast to check if player is directly in range
            return attackState;
        }
        else if (ratStateManager.DistanceFromCurrentTarget >= ratStateManager.MaximumChaseDistance || (!hasPlayerInSight && Vector3.Distance(ratStateManager.RatNavMeshAgent.destination, transform.position) < .5)) //Transition to RetreatState
        {
            ratStateManager.CurrentTarget = null;
            //Later remove cuz it will be the retreat state
            ratStateManager.RatSpeed = .4f;
            ratStateManager.ChangeRatSpeed();
            return idleState;
        }
        else if (ratStateManager.DistanceFromCurrentTarget <= 2) //DIRECTOR AI
        {
            ratStateManager.RatSpeed = .5f; //DIRECTOR AI
            ratStateManager.ChangeRatSpeed();
        }
        else if (ratStateManager.DistanceFromCurrentTarget > 2)
        {
            ratStateManager.RatSpeed = .6f;
            ratStateManager.ChangeRatSpeed();
        }
        
        return this;
    }

    private void MoveTowardsCurrentTarget(RatStateManager ratStateManager)
    {
        RaycastHit hit;
        //raycast goes a bit up
        float height = .2f;
        var transform1 = ratStateManager.CurrentTarget.transform;
        Vector3 playerStartPoint = new Vector3(transform1.position.x, transform1.position.y + height, transform1.position.z);
        var position = transform.position;
        Vector3 ratStartPoint = new Vector3(position.x, position.y + height, position.z);

        if (Physics.Linecast(playerStartPoint, ratStartPoint, out hit, ignoreWhenInLineOfSight))
        {
            hasPlayerInSight = false;
        }
        else
        {
            hasPlayerInSight = true;
            ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
        }

    }
    
}
