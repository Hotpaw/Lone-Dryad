using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public State chaseState;
    public bool chasing;
    public override State RunCurrentState()
    {
        if (!chasing)
        {
            return this;
        }
        else if (chasing)
        {
            return chaseState;
        }
        else
        {
            return this;
        }

    }
}
