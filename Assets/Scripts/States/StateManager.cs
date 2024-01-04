using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    
    public State currentState;
    public static StateManager INSTANCE;
    private void Start()
    {
        INSTANCE = this;
    }
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
    public void ChangeState(string state)
    {
        switch (state)
        {
            case "ATTACKTOIDLE": currentState = WereWolf.INSTANCE.IdleState;
                FindObjectOfType<TreeScript>().gameObject.GetComponent<Health>().TakeDamage(1);
                break;
        }
    }
}
