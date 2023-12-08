using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowingAttackBoon : InteractableObject
{
    public override void Interact()
    {
        GameValueManager.INSTANCE.thePowerToThrowNuts = true;
        Stage2Event.INSTANCE.SpawnBats();
        Destroy(gameObject, 0.1f);
        
       
    }

   
}
