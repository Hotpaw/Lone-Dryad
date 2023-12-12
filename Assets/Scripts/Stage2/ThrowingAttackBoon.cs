using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowingAttackBoon : InteractableObject
{
    public GameObject batTrigger;
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("YOU CAN NOW THROW NUTS! USE LMB OR X", Color.green);
        GameValueManager.INSTANCE.thePowerToThrowNuts = true;
       
        Stage2Event.INSTANCE.SpawnBats();
        batTrigger.SetActive(true);
        Destroy(gameObject, 0.1f);

    }


}
