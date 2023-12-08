using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowingAttackBoon : InteractableObject
{
    public override void Interact()
    {
        GameValueManager.INSTANCE.thePowerToThrowNuts = true;
        GameValueManager.INSTANCE.progressActive = true;
        Stage2Event.INSTANCE.SpawnBats();
        TreeState2.INSTANCE.batsReleased = true;
        Destroy(gameObject, 0.1f);
       
    }

   
}
