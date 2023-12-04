using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    public bool firstTime;
    public DistanceChecker distanceChecker;
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.carryingWater > 0)
        {            
            FindObjectOfType<Movement>().IncreaseSpeed();
            FindObjectOfType<Movement>().isCrawling = false;
            GameValueManager.INSTANCE.waterLevel += GameValueManager.INSTANCE.carryingWater;
            PopUpText.INSTANCE.PopUpMessage("Watered tree", Color.blue);
            if (GameValueManager.INSTANCE.waterLevel > 100)
                GameValueManager.INSTANCE.waterLevel = 100;
            GameValueManager.INSTANCE.addingWater = true;
            //GameValueManager.INSTANCE.carryingWater = 0;
            if(!firstTime)
            {
                distanceChecker.active = true;
                firstTime = true;
            }
        }
    }
}
