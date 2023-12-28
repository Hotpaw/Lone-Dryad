using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState1 : State
{
    public static TreeState1 INSTANCE;
    public float seedTimer;
    public float spawnSeedAt;
    public float triggerTime;

    public bool trigger1;
    public bool trigger2;
    public bool once;
    public bool once2;
    public bool once3;

    public void Awake()
    {
        spawnSeedAt = 3;
        


        FindAnyObjectByType<Movement>().isCrawling = true;
        FindAnyObjectByType<Movement>().DecreaseSpeed();
    }
    private void Start()
    {
        GameValueManager.INSTANCE.progressActive = true;
        PopUpText.INSTANCE.PopUpMessage("I need to get Water for my tree", Color.gray, 3);
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

                //spawnSeedAt = Random.Range(5, 25);
            }
            if (seedTimer > triggerTime)
                trigger2 = true;
            if (trigger2 && !once2)
            {
                PopUpText.INSTANCE.PopUpMessage("I have to jump on the centipedes to squash them", Color.green, 3);
                EnemySpawner.INSTANCE.SpawnStage1();
                once2 = true;
            }
            if (!once3 && seedTimer > triggerTime + 20)
            {
                EnemySpawner.INSTANCE.SpawnStage1();
                once3 = true;
            }

            return this;
        }
        else
        {
            return TreeState2.INSTANCE;
        }
    }
}
