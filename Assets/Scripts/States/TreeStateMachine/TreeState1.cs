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
        spawnSeedAt = Random.Range(15, 25);       
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
            seedTimer += Time.deltaTime;
            if (seedTimer > spawnSeedAt) 
            {
                EnemySpawner.INSTANCE.SpawnEnemy(1, EnemySpawner.INSTANCE.transform.position);
                seedTimer = 0;
                spawnSeedAt = Random.Range(5, 25);
            }            
            return this;
        }
        else
        {
            return TreeState2.INSTANCE;
        }
    }
}
