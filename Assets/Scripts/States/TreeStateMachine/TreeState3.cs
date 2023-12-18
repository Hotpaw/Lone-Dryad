using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState3 : State
{
    public static TreeState3 INSTANCE;
    bool once;
    public int numberOfCrystallPieces;
    public int maxCrystals;

    public void Awake()
    {
        GameValueManager.INSTANCE.progressActive = false;
        INSTANCE = this;

    }
    private void Update()
    {
        if(numberOfCrystallPieces == 5)
        {
            GameValueManager.INSTANCE.progressActive = true;
        }
    }
    public override State RunCurrentState()
    {
        return this;
    }

}