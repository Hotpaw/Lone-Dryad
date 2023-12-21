using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableTree : InteractableObject
{
    public bool firstTime;
    public DistanceChecker distanceChecker;
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.gotWater)
        {    
            PopUpText.INSTANCE.PopUpMessage("The Trees Health Return", Color.blue, 2);            
            GameValueManager.INSTANCE.addingWater = true;
            StartCoroutine(StopCrawling());

            if (!firstTime)
            {
                distanceChecker.active = true;
                firstTime = true;
            }
        }
        if (GameValueManager.INSTANCE.nextLevelAvailable)
        {
            SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);
        }
    }
    public IEnumerator StopCrawling()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<Movement>().IncreaseSpeed();
    }
}
