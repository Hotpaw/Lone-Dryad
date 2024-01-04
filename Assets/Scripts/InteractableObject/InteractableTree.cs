using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableTree : InteractableObject
{
    public bool firstTime;    
    public override void Interact()
    {
        //if (GuideTimer.INSTANCE.canStartGuide)
        //{
        //    GuideTimer.INSTANCE.guideIsActive = true;
        //}
        if (GameValueManager.INSTANCE.gotWater)
        {
            PopUpText.INSTANCE.PopUpMessage("The Trees Health Return", Color.blue, 2);
            GameValueManager.INSTANCE.addingWater = true;
            StartCoroutine(StopCrawling());
            
        }
        if (GameValueManager.INSTANCE.nextLevelAvailable && SceneManager.GetActiveScene().name != "Stage5")
        {
            SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);
        }
        if (GameValueManager.INSTANCE.nextLevelAvailable && SceneManager.GetActiveScene().name == "Stage5")
        {
            Debug.Log("INT");
            TreeState5.INSTANCE.ActivateWereWolfEvent();
        }
    }
    public IEnumerator StopCrawling()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<Movement>().IncreaseSpeed();
    }

}
