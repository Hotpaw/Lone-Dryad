using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WerewolfIdleState : State
{
    Animator animator;
    public int cooldown = 5;
    float timer;
    private bool idleSet = false;
    public override State RunCurrentState()
    {
        animator = WereWolf.INSTANCE.animator;
        timer += Time.deltaTime;
        if (!idleSet)
        {
            animator.SetBool("Idle", true);
            idleSet = true;
        }
     

        // Check if the timer has exceeded the cooldown period
        if (timer >= cooldown)
        {
            // Reset the timer if you want the cooldown to start again after jumping
            timer = 0;
            idleSet = false;
            return WereWolf.INSTANCE.JumpState;
        }

        // Continue in the current state if the timer has not yet exceeded the cooldown
        return this;
    }

    
}
