using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState6 : State
{
    public static TreeState6 INSTANCE;
    bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public override State RunCurrentState()
    {
        if (GameValueManager.INSTANCE.treeLevel == 6)
        {
            return this;
        }
        else
        {
            return this;
        }
    }
}