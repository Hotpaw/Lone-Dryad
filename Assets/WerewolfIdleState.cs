using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WerewolfIdleState : State
{
    Animator animator;
    public int cooldown = 5;
    public float timer;
    public bool idleSet = false;
    public override State RunCurrentState()
    {
        animator = WereWolf.INSTANCE.animator;
        timer += Time.deltaTime;
        if (!idleSet)
        {
            WereWolf.INSTANCE.FlipBasedOnTreePosition();
            animator.SetTrigger("Idle");
            idleSet = true;
        }
     

        // Check if the timer has exceeded the cooldown period
        if (timer >= cooldown && !WereWolf.INSTANCE.moveToAttack)
        {
            // Reset the timer if you want the cooldown to start again after jumping
            timer = 0;
            idleSet = false;
            return WereWolf.INSTANCE.JumpState;
        }
        else if(timer >= cooldown && WereWolf.INSTANCE.moveToAttack)
        {
            timer = 0;
            idleSet = false;
            return WereWolf.INSTANCE.IntroState;
        }

        // Continue in the current state if the timer has not yet exceeded the cooldown
        return this;
    }

    
}
