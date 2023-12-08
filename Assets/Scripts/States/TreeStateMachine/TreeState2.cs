using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState2 : State
{
    public static TreeState2 INSTANCE;
    bool once;
    public bool batsReleased = false;
    bool spawnCD = false;

    public void Start()
    {
        GameValueManager.INSTANCE.nextStageScore = 100;
        if (GameValueManager.INSTANCE.treeLevel == 2)
        {

            FindAnyObjectByType<Movement>().isCrawling = false;
            FindAnyObjectByType<Movement>().IncreaseSpeed();
            FindAnyObjectByType<TreeScript>().GetComponent<Health>().HealToMax();
            DistanceChecker[] checkerfs = FindObjectsOfType<DistanceChecker>();
            foreach (DistanceChecker checker in checkerfs)
            {
                checker.enabled = false;
            }
        }
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (batsReleased && GameValueManager.INSTANCE.treeIsALive)
        {
            if (!spawnCD)
            {
                StartCoroutine(SpawnBats());
            }
        }
    }
    public override State RunCurrentState()
    {
        return this;
    }
    IEnumerator SpawnBats()
    {
        spawnCD = true;
        yield return new WaitForSeconds(Random.Range(5, 15));
        EnemySpawner.INSTANCE.SpawnStage2();
        spawnCD = false;
    }
}
