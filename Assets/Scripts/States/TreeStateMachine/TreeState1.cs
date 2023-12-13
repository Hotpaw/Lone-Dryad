using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState1 : State
{
    public static TreeState1 INSTANCE;
    public float seedTimer;
    public float spawnSeedAt;
    public float triggerTimer;
    public List<Transform> spawnPoints;
    
    public bool trigger1;
    public bool trigger2;
    bool once;

    public void Awake()
    {
        spawnSeedAt = 10;      
    }
    private void Start()
    {
        PopUpText.INSTANCE.PopUpMessage("I need to get Water for my tree", Color.gray);
        
        GameValueManager.INSTANCE.progressActive = true;
        FindAnyObjectByType<Movement>().isCrawling = true;
        FindAnyObjectByType<Movement>().DecreaseSpeed();
    }

    public override State RunCurrentState()
    {        
        if (GameValueManager.INSTANCE.treeLevel == 1)
        {
            if (GameValueManager.INSTANCE.addingWater)
                trigger1 = true;
            if (trigger1)
                seedTimer += Time.deltaTime;
            if (!once && seedTimer > spawnSeedAt) 
            {
                once = true;
                EnemySpawner.INSTANCE.SpawnEnemy();
                seedTimer = 0;
                //spawnSeedAt = Random.Range(5, 25);
            }
            if (seedTimer == triggerTimer)
                trigger2 = true;
            if (trigger2)
            {
                EnemySpawner.INSTANCE.SpawnStage1();
                trigger2 = false;
            }

            return this;
        }
        else
        {
            return TreeState2.INSTANCE;
        }
    }
}
