using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    
    public State currentState;

   
    void Update()
    {
            RunStateMachine();
    }
    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            //Switch to next state
            SwitchToTheNextState(nextState);

        }
    }
    public void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
