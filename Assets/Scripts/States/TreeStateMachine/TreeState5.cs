using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState5 : State
{
    public static TreeState5 INSTANCE;
    bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
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