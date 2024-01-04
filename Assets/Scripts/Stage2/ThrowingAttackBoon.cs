using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowingAttackBoon : InteractableObject
{
    public GameObject batTrigger;
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("You can now throw akorns", Color.green, 3f, true);
        GameValueManager.INSTANCE.thePowerToThrowNuts = true;
       
        Stage2Event.INSTANCE.SpawnBats();
        batTrigger.SetActive(true);
        Destroy(gameObject, 0.1f);

    }


}
