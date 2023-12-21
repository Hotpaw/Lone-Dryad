using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePlant : InteractableObject
{
    public GameObject parent;
    public override void Interact()
    {
        GameValueManager.INSTANCE.thePowerToPlant = true;
        PopUpText.INSTANCE.PopUpMessage("You gained the power to regrow plants",Color.black,5f);
        Destroy(parent);
    }

    
}
