using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : InteractableObject
{
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("Got water", Color.blue);
        GameValueManager.INSTANCE.gotWater = true;   
    }
}