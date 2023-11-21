using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    public override void Interact()
    {
        GameValueManager.INSTANCE.waterLevel += GameValueManager.INSTANCE.carryingWater;
        if (GameValueManager.INSTANCE.waterLevel > 100)
            GameValueManager.INSTANCE.waterLevel = 100;
        GameValueManager.INSTANCE.carryingWater = 0;
    }


}
