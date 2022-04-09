using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    //Chase the player until he is no longer in sight (Retreat)
    //or start attacking when he is in range (Attack)
    
    public override State Tick(RatStateManager ratStateManager)
    {
        //MoveTowardsCurrentTarget(ratStateManager);
        RotateTowardsCurrentTarget(ratStateManager);
        return this;
    }

    private void MoveTowardsCurrentTarget(RatStateManager ratStateManager)
    {
        ratStateManager.RatRB.velocity = transform.right * ratStateManager.RatSpeed;
    }

    private void RotateTowardsCurrentTarget(RatStateManager ratStateManager)
    {
        ratStateManager.RatNavMeshAgent.enabled = true;
        ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
        //ratStateManager.transform.rotation = Quaternion.Slerp(ratStateManager.transform.rotation, ratStateManager.RatNavMeshAgent.transform.rotation, ratStateManager.RotationSpeed/Time.deltaTime);
    }
}
