using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    public bool firstTime;
    public DistanceChecker distanceChecker;
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.gotWater)
        {            
            FindObjectOfType<Movement>().IncreaseSpeed();
            FindObjectOfType<Movement>().isCrawling = false;
            PopUpText.INSTANCE.PopUpMessage("Watered tree", Color.blue);            
            GameValueManager.INSTANCE.addingWater = true; 

            if(!firstTime)
            {
                distanceChecker.active = true;
                firstTime = true;
            }
        }
    }
}
