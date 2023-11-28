using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState1 : State
{
    public static TreeState1 INSTANCE;
    bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public override State RunCurrentState()
    {        
        if (GameValueManager.INSTANCE.treeLevel == 1)
        {            
            if (!once && GameValueManager.INSTANCE.progressScore >= 40)
            {
                once = true;
                EnemySpawner.INSTANCE.SpawnEnemy(0, new Vector2(33, 4));
            }
            return this;
        }
        else
        {
            return TreeState2.INSTANCE;
        }
    }
}
