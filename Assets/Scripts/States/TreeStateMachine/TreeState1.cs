using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState1 : State
{
    public static TreeState1 INSTANCE;
    public float seedTimer;
    public float spawnSeedAt;

    public bool watered;    
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
                watered = true;
            if (watered && !once)
                seedTimer += Time.deltaTime;
            if (!once && seedTimer > spawnSeedAt) 
            {
                EnemySpawner.INSTANCE.SpawnEnemy();
                seedTimer = 0;
                //spawnSeedAt = Random.Range(5, 25);
                once = true;
            }            
            return this;
        }
        else
        {
            return TreeState2.INSTANCE;
        }
    }
}
