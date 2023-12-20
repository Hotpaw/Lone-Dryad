using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState5 : State
{
    public static TreeState5 INSTANCE;
    bool once;

    public void Awake()
    {
      
        INSTANCE = this;
      
    }
    public override State RunCurrentState()
    {
        if (GameValueManager.INSTANCE.treeLevel == 5)
        {
            return this;
        }
        else
        {
            return TreeState6.INSTANCE;
        }
    }
}