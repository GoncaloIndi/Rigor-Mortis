using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    //Base class for all the states
    public virtual State Tick(RatStateManager ratStateManager)
    {
        return this;
    }
}
