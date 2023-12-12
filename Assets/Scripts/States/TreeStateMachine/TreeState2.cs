using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState2 : State
{
    public static TreeState2 INSTANCE;
    bool once;
    public bool enemyWaveActive = false;
    bool batCD = false;
    bool seedCD = false;

    public void Start()
    {
        

        FindAnyObjectByType<Movement>().isCrawling = false;
        FindAnyObjectByType<Movement>().IncreaseSpeed();
        FindAnyObjectByType<TreeScript>().GetComponent<Health>().HealToMax();
        DistanceChecker[] checkerfs = FindObjectsOfType<DistanceChecker>();
        foreach (DistanceChecker checker in checkerfs)
        {
            checker.enabled = false;
        }


        INSTANCE = this;

    }
    private void Update()
    {
        if (enemyWaveActive && GameValueManager.INSTANCE.treeIsALive)
        {
            if (!batCD)
            {
                StartCoroutine(SpawnBats());
            }
        }
        if (enemyWaveActive && GameValueManager.INSTANCE.treeIsALive)
        {
            if (!seedCD)
            {
                StartCoroutine(SpawnSeeds());
            }
        }
    }
    public override State RunCurrentState()
    {
        return this;
    }
    IEnumerator SpawnSeeds()
    {
        seedCD = true;
        if (seedCD)
        {
            for (int i = 0; i < 1; i++)
                EnemySpawner.INSTANCE.SpawnEnemy();
        }
        yield return new WaitForSeconds(Random.Range(13, 15));

        seedCD = false;
    }
    IEnumerator SpawnBats()
    {
        batCD = true;
        EnemySpawner.INSTANCE.SpawnStage2();
        yield return new WaitForSeconds(Random.Range(9, 15));
        batCD = false;
    }
    public IEnumerator StartBatTimer()
    {
        yield return new WaitForSeconds(10f);
        enemyWaveActive = true;
    }

}
