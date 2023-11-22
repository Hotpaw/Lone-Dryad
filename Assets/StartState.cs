using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{

    public State attackState;
    public override State RunCurrentState()
    {
        return this;
    }


}
