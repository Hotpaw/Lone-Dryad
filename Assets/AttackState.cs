using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public State startState;
    public override State RunCurrentState()
    {
        return this;
    }

   
}
