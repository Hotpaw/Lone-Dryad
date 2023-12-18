using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPickup : InteractableObject
{
    public bool oneCrystal;
    public GameObject crystal;
    public override void Interact()
    {
        // Koden h�r k�rs m�r du aktiver interactable object i scenen med B eller E
        
       if (!oneCrystal && TreeState3.INSTANCE.numberOfCrystallPieces < TreeState3.INSTANCE.maxCrystals)
       {
         TreeState3.INSTANCE.numberOfCrystallPieces++;
         oneCrystal = true;
         Destroy(crystal);

         Debug.Log("picked up crystal!");
        
       }
       else
       {
            Debug.Log("Crystal not picked up");
       }
        
        
        //PopUpText.INSTANCE.PopUpMessage("Picked up crystal", Color.black, 2);

    }

 
}
