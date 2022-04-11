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
        
        if (ratStateManager.DistanceFromCurrentTarget <= ratStateManager.MinimumAttackDistance) //Transition to AttackState
        {
            //Raycast to check if player is directly in range
            return attackState;
        }
        else if (ratStateManager.DistanceFromCurrentTarget >= ratStateManager.MaximumChaseDistance) //Transition to RetreatState
        {
            ratStateManager.CurrentTarget = null;
            //Later remove cuz it will be the retreat state
            ratStateManager.RatSpeed = .3f;
            ratStateManager.ChangeRatSpeed();
            return idleState;
        }
        
        else
        {
            return this;
        }
    }

    private void MoveTowardsCurrentTarget(RatStateManager ratStateManager)
    {
        ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
    }
    
}
