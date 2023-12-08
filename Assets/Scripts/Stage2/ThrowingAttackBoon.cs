using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowingAttackBoon : InteractableObject
{
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("YOU CAN NOW THROW NUTS! USE LMB OR X", Color.green);
        GameValueManager.INSTANCE.thePowerToThrowNuts = true;
        GameValueManager.INSTANCE.progressActive = true;
        Stage2Event.INSTANCE.SpawnBats();
        TreeState2.INSTANCE.batsReleased = true;
        Destroy(gameObject, 0.1f);
       
    }

   
}
