using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    public bool firstTime;
    public GameObject distanceChecker;
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.carryingWater > 0)
        {            
            FindObjectOfType<Movement>().IncreaseSpeed();
            GameValueManager.INSTANCE.waterLevel += GameValueManager.INSTANCE.carryingWater;
            PopUpText.INSTANCE.PopUpMessage("Watered tree", Color.blue);
            if (GameValueManager.INSTANCE.waterLevel > 100)
                GameValueManager.INSTANCE.waterLevel = 100;
            GameValueManager.INSTANCE.carryingWater = 0;
            if(!firstTime)
            {
                Instantiate(distanceChecker, new Vector3(-18,0,0), Quaternion.identity);
                Instantiate(distanceChecker, new Vector3(-30, 0, 0), Quaternion.identity);
                Instantiate(distanceChecker, new Vector3(15, 0, 0), Quaternion.identity);
                Instantiate(distanceChecker, new Vector3(25, 0, 0), Quaternion.identity);
                firstTime = true;
            }

        }
    }
}
