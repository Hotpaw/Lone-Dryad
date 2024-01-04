using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolfAttackState : State
{
    bool isAttacking = false;
    public override State RunCurrentState()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            WereWolf.INSTANCE.animator.SetTrigger("Attack");
        }
        Debug.Log(" ATTACK");
        return this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  
}
