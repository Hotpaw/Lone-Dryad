using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState1 : State
{
    public static TreeState1 INSTANCE;
    bool once;
    public float seedTimer;
    public float spawnSeedAt;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
        spawnSeedAt = Random.Range(15, 25);
        PopUpText.INSTANCE.PopUpMessage("I need to get Water for my tree", Color.gray);
    }

    public override State RunCurrentState()
    {        
        if (GameValueManager.INSTANCE.treeLevel == 1)
        {
            seedTimer += Time.deltaTime;
            if (seedTimer > spawnSeedAt) 
            {
                EnemySpawner.INSTANCE.SpawnEnemy(1, EnemySpawner.INSTANCE.transform.position);
                seedTimer = 0;
                spawnSeedAt = Random.Range(5, 25);
            }
            //if (!once && GameValueManager.INSTANCE.progressScore >= 40)
            //{
            //    once = true;
            //    EnemySpawner.INSTANCE.SpawnEnemy(0, new Vector2(33, 4));
            //}
            return this;
        }
        else
        {
            return TreeState2.INSTANCE;
        }
    }
}
