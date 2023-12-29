using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPickup : InteractableObject
{
    public bool oneCrystal;
    public GameObject crystal;
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.thePowerToPickUpCrystals)
        {
            GameValueManager.INSTANCE.numberOfCrystallPieces++;
            PopUpText.INSTANCE.PopUpMessage("Found " + GameValueManager.INSTANCE.numberOfCrystallPieces +"/" + GameValueManager.INSTANCE.maxNumberOfCrystallPieces + " Crystals", Color.black, 2f);
            oneCrystal = true;
            Destroy(crystal);
        }
    }


}
