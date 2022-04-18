using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private ChaseState chaseState;

    private void Awake()
    {
        chaseState = GetComponent<ChaseState>();
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        //Debug.Log("AttackStarted");
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        if (ratStateManager.DistanceFromCurrentTarget >= 2)
        {
            return chaseState;
        }
        return this;
    }
}
