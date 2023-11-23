using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public State attackState;
    public bool attack;

    public override State RunCurrentState()
    {
        if (!attack)
        {
            return this;
        }
        else if (attack)
        {
            return attackState;
        }
        else
        {
            return this;
        }

    }
}
