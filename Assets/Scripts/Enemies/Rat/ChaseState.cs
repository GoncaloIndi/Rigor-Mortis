using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    //Chase the player until he is no longer in sight (Retreat)
    //or start attacking when he is in range (Attack)

    private AttackState attackState;

    private void Awake()
    {
        attackState = GetComponent<AttackState>();
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        MoveTowardsCurrentTarget(ratStateManager);
        
        if (ratStateManager.DistanceFromCurrentTarget <= ratStateManager.MinimumAttackDistance)
        {
            return attackState;
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
