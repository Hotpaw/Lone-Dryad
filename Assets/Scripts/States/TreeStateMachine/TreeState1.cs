using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState1 : State
{
    public static TreeState1 INSTANCE;

    //Intro
    public blackOut blackOut;
    public cameraFollow cameraFoll;
    public GameObject interactableTree;
    
    public bool startOnce1;
    public bool startOnce2;      

    public bool cameraZoomOut;
    public float cameraZoomScale;

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
    }
    private void Start()
    {
        cameraFoll.cameraDistance = 3;
        GameValueManager.INSTANCE.progressActive = true;        
    }
    private void Update()
    {
        if (GameValueManager.INSTANCE.gotWater || GameValueManager.INSTANCE.nextLevelAvailable)
        {
            interactableTree.SetActive(true);
        }
        else
            interactableTree.SetActive(false);

        if (!startOnce1) 
        {
            StartCoroutine(YieldZoomOut());            
        }
        if (cameraFoll.cameraDistance < 11 && startOnce1)
            cameraFoll.cameraDistance += 10 * Time.deltaTime;
        else if(startOnce1 && !startOnce2)
        {
            PopUpText.INSTANCE.PopUpMessage("My tree needs water right now, I need to go get some for it", Color.white, 3);
            startOnce2 = true;
        }

    }
    public IEnumerator YieldZoomOut()
    {
        yield return new WaitForSeconds(1.5f);
        startOnce1 = true;
    }
    public IEnumerator Yieldblackout()
    {        
        yield return new WaitForSeconds(3);
        blackOut.startBlackOut = true;
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
                PopUpText.INSTANCE.PopUpMessage("I should squash the centepiedes by jumping on them", Color.white, 3);
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
