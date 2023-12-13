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
            PopUpText.INSTANCE.PopUpMessage("Watered tree", Color.blue);            
            GameValueManager.INSTANCE.addingWater = true;
            StartCoroutine(StopCrawling());

            if (!firstTime)
            {
                distanceChecker.active = true;
                firstTime = true;
            }
        }
    }
    public IEnumerator StopCrawling()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<Movement>().IncreaseSpeed();
    }
}
