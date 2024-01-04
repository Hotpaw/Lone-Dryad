using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolfAttackState : State
{

    public bool isAttacking = false;
    public bool idle = false;



    public override State RunCurrentState()
    {

        if (!isAttacking)
        {
            // Start the attack coroutine and stay in this state
            isAttacking = true;

            StartCoroutine(Attack());
        }

        // Stay in the current state until the attack is finished
        return this;
    }

    IEnumerator Attack()
    {
        Debug.Log("WA");
        WereWolf.INSTANCE.animator.SetTrigger("Attack");
        yield return new WaitForSeconds(WereWolf.INSTANCE.GetAnimationClipDuration("werewolf_attack"));
        FindObjectOfType<TreeScript>().GetComponent<Health>().TakeDamage(1);
        idle = true;
    }





    // Update is called once per frame


}
