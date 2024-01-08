using DG.Tweening;
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

    public Vector2 batTimer;
    public Vector2 seedTimer;
    public void Start()
    {

        Invoke("StartShake", 1);
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
        if(GameValueManager.INSTANCE.progressScore == GameValueManager.INSTANCE.nextStageScore)
        {
            enemyWaveActive = false;
        }
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
    }public void StartShake()
    {
       StartCoroutine(ShakeEffect());
    }
    IEnumerator ShakeEffect()
    {
        FindAnyObjectByType<cameraFollow>().enabled = false;
        Camera.main.gameObject.transform.DOShakePosition(1.8f, 2, 7, 60);
        PopUpText.INSTANCE.PopUpMessage("There's a rumble in the cave, something has happened", Color.white, 3);
        yield return new WaitForSeconds(1);
        FindAnyObjectByType<cameraFollow>().enabled = true;
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
        yield return new WaitForSeconds(Random.Range(seedTimer.x, seedTimer.y));

        seedCD = false;
    }
    IEnumerator SpawnBats()
    {
        batCD = true;
        EnemySpawner.INSTANCE.SpawnStage2();
        yield return new WaitForSeconds(Random.Range(batTimer.x, batTimer.y));
        batCD = false;
    }
    public IEnumerator StartBatTimer()
    {
        yield return new WaitForSeconds(10f);
        enemyWaveActive = true;
    }

}
