using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{

    public State attackState;
    public bool attack;
    public override State RunCurrentState()
    {
        if (!attack)
        {
            return this;
        }
        else
        {
            return attackState;
        }
    }


}
