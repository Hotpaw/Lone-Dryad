using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPickup : InteractableObject
{
    public bool oneCrystal;
    public GameObject crystal;
    public override void Interact()
    {

        GameValueManager.INSTANCE.numberOfCrystallPieces++;
        PopUpText.INSTANCE.PopUpMessage("Found A Crystal", Color.black, 2f);
        oneCrystal = true;
        Destroy(crystal);



    }


}
