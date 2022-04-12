using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override State Tick(RatStateManager ratStateManager)
    {
        //Debug.Log("AttackStarted");
        ratStateManager.RatSpeed = 0;
        ratStateManager.ChangeRatSpeed();
        return this;
    }
}
