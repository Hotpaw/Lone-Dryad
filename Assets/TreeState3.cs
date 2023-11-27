using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState3 : State
{
    public static TreeState3 INSTANCE;
    bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public override State RunCurrentState()
    {
        if (GameValueManager.INSTANCE.treeLevel == 3)
        {
            return this;
        }
        else
        {
            return TreeState4.INSTANCE;
        }
    }
}