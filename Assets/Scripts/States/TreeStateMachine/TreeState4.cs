using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState4 : State
{
    public static TreeState4 INSTANCE;
    bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        
    }
    public override State RunCurrentState()
    {
        if (GameValueManager.INSTANCE.treeLevel == 4)
        {
            return this;
        }
        else
        {
            return TreeState5.INSTANCE;
        }
    }
}