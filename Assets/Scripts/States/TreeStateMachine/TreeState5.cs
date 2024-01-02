using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeState5 : State
{
    public static TreeState5 INSTANCE;
    bool once;
    public Animator wereWolfEyes;
    public void Start()
    {
        PopUpText.INSTANCE.PopUpMessage("The water is Gone, i should climb the branches to find out what happened", Color.black,5f);
        INSTANCE = this;
      
    }
    public override State RunCurrentState()
    {
        
        
            return this;
     
    }
    public void ActivateWereWolfEvent()
    {
        wereWolfEyes.SetTrigger("EyeTrigger");
        SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);
    }
    public void NextLevel()
    {
        GameValueManager.INSTANCE.nextLevelAvailable = true;
    }
}