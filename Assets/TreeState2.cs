using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState2 : State
{
    public static TreeState2 INSTANCE;
    bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public override State RunCurrentState()
    {
        if (GameValueManager.INSTANCE.treeLevel == 2)
        {
            if (!once)
            {
                EnemySpawner.INSTANCE.SpawnEnemy(0, new Vector2(27f, -4f));
                EnemySpawner.INSTANCE.SpawnEnemy(0, new Vector2(-43f, 10f));
                once = true;
            }
            return this;
        }
        else 
        { 
            return TreeState3.INSTANCE; 
        }
    }
}
