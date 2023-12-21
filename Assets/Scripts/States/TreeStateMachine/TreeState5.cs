using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState5 : State
{
    public static TreeState5 INSTANCE;
    bool once;

    public void Start()
    {
        PopUpText.INSTANCE.PopUpMessage("The water is Gone, I can climb the tree branches to check it out", Color.black,5f);
        INSTANCE = this;
      
    }
    public override State RunCurrentState()
    {
        
        if(GameValueManager.INSTANCE.numberOfCrystallPieces == 4)
        {
            GameValueManager.INSTANCE.nextLevelAvailable = true;
        }
            return this;
     
    }
}