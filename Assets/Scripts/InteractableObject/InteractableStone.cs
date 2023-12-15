using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableStone : InteractableObject
{
    public bool once;
    public GameObject stone;

    public override void Interact()
    {
        if (!once && GameValueManager.INSTANCE.stones < GameValueManager.INSTANCE.maxStones)
        {            
            GameValueManager.INSTANCE.thePowerToThrowNuts = true;
            once = true;
            GameValueManager.INSTANCE.stones++;    
            Destroy(stone);
        }
    }
}