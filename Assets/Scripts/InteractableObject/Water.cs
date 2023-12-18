using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : InteractableObject
{
    public override void Interact()
    {
       
        GameValueManager.INSTANCE.gotWater = true;   
    }
}