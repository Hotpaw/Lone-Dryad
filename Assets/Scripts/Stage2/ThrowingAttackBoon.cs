using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowingAttackBoon : InteractableObject
{
    public GameObject batTrigger;
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("Use Your Action Key to Attack", Color.green, 0.5f);
        GameValueManager.INSTANCE.thePowerToThrowNuts = true;
       
        Stage2Event.INSTANCE.SpawnBats();
        batTrigger.SetActive(true);
        Destroy(gameObject, 0.1f);

    }


}
