using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class WereWolfAttackState : State
{
    public bool isAttacking = false;
    public bool idle = false;
    public override State RunCurrentState()
    {
        if (idle)
        {
            isAttacking = false;
            idle = false;
            return WereWolf.INSTANCE.IdleState;
        }
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(Attack());
            return stat(this);
        }

        else
        {
            return this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator Attack()
    {
       
        Debug.Log("WA");
        WereWolf.INSTANCE.animator.SetTrigger("Attack");
        yield return new WaitForSeconds(WereWolf.INSTANCE.GetAnimationClipDuration("werewolf_attack"));
        FindObjectOfType<TreeScript>().GetComponent<Health>().TakeDamage(1);
        idle = true;
       


    }
    private State stat(State state)
    {
        if(idle)
        {
            state = WereWolf.INSTANCE.IdleState;
        }
        else
        {
            stat(this);
        }
        return state;
    }
    // Update is called once per frame

}
