using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : InteractableObject
{
    public float waterAmount;

    public override void Interact()
    {
        //Här
        GameValueManager.INSTANCE.carryingWater = waterAmount;        
    }
}