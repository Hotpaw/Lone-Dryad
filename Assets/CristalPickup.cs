using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPickup : InteractableObject
{
    public override void Interact()
    {
        // Koden här körs mär du aktiver interactable object i scenen med B eller E
        TreeState3.INSTANCE.numberOfCrystallPieces++;
        Debug.Log("I was pressed");
    }

 
}
