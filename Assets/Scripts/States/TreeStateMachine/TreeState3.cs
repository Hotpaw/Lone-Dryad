using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeState3 : State
{
    //Checking stuff
    public float distance;

    public static TreeState3 INSTANCE;
    public bool once;

    //Intro
    public GameObject swarm1;
    public GameObject cameraPoint2;
    public Transform cameraPoint2Target;
    public Transform triggerPoint;
    public bool startOnce;
    public bool startMovingCamera;
    public bool startScene;
    
    public GameObject waterPosition;
    public GameObject playerPosition;
    public GameObject trigger2Position;
    public GardenGnome1 gardenGnome;
    public GardenGnome2 gardenGnome2;
    public cameraFollow cameraFoll;
    
    public bool trigger1;
    public bool trigger2;
    public bool trigger3;
    public bool enemyAttacking;
    public bool enemyAttackingOnce;
    

    //Cave switches
    public GameObject caveOne;
    public GameObject caveTwo;

    
    public float checkDist;
    public float checkDist2;

    //For ending
    public blackOut blackOut;
    public bool trigger4;
    public bool trigger5;    
    public bool once2;
    public bool once3;
    public bool once4;
    public bool isBuildingCrystal;
    public bool cameraZoomOut;
    public float cameraZoomScale;
    public GameObject cavefull;
    public GameObject background;
    public GameObject caveleft;
    public GameObject shieldCrystal;
    public GameObject shieldCrystalLight;
    public GameObject gardenGnome3;

    public void Start()
    {        
        INSTANCE = this;
        cameraZoomScale = cameraFoll.cameraDistance;
    }
    private void Update()
    {
        distance = Vector2.Distance(cameraPoint2.transform.position, triggerPoint.position);
        if (!startScene)
        {
            cameraPoint2Target.position = triggerPoint.position;
            cameraFoll.player = GameObject.FindGameObjectWithTag("CameraPoint2").transform;
            StartCoroutine(YieldCameraStart());
            if (startMovingCamera)
            {
                cameraPoint2.transform.position = Vector2.MoveTowards(cameraPoint2.transform.position, cameraPoint2Target.position, 5 * Time.deltaTime);
                if (Vector2.Distance(cameraPoint2.transform.position, cameraPoint2Target.position) < 1f)  
                {
                    if (!startOnce)
                    {
                        StartCoroutine(YieldStart());
                        cameraPoint2Target.position = playerPosition.transform.position;
                    }
                    if (startOnce)
                    {
                        StartCoroutine(YieldStart());
                    }
                }
            }
                          
        }
        if (!trigger1)
        {            
            checkDist = Vector2.Distance(waterPosition.transform.position, playerPosition.transform.position);
            if (checkDist < 4)
            {
                if (!once)
                {
                    gardenGnome.SpookedGnome();
                    once = true;
                    StartCoroutine(YieldTrigger());
                }
            }
        }
        else if (!trigger2)
        {
            checkDist2 = Vector2.Distance(trigger2Position.transform.position, playerPosition.transform.position);            
            if (checkDist2 < 1.2f)
            {
                if (!once)
                {                    
                    once = true;
                    trigger2 = true;
                }
                StartCoroutine(YieldTrigger());
            }
        }        
        if(GameValueManager.INSTANCE.numberOfCrystallPieces > 5 && !trigger3) 
        {
            GameValueManager.INSTANCE.stormStrenght +=4;
            trigger3 = true;
        }        
        if(GameValueManager.INSTANCE.progressScore >= 30)
        {
            caveOne.SetActive(true);
            caveTwo.SetActive(true);
        }
        if (enemyAttacking && !enemyAttackingOnce)
        {
            enemyAttackingOnce = true;
            PopUpText.INSTANCE.PopUpMessage("I have to stop the enemies before i go on", Color.black, 3);
            caveOne.SetActive(false);
            caveTwo.SetActive(false);
        }    
        //Start cutscene
        if (trigger4 && !once2)
        {
            once2 = true;
            blackOut.fadeForSec = 2;
            blackOut.startBlackOut = true;            
        }
        if (blackOut.fadedTime > 1 && !once3)
        {
            GameValueManager.INSTANCE.stormStrenght += 8;
            once3 = true;
            cavefull.gameObject.SetActive(true);
            shieldCrystal.gameObject.SetActive(true);
            isBuildingCrystal = true;
            background.gameObject.SetActive(false);

            playerPosition.transform.position = new Vector3(57.5f, -9f);
            gardenGnome3.gameObject.SetActive(true);            
            StartCoroutine(Yieldblackout());
        }
        if (trigger5 && blackOut.fadedTime > 1 && !once4)
        {

            once4 = true;
            background.gameObject.SetActive(true);
            cavefull.gameObject.SetActive(false);
            caveleft.gameObject.SetActive(false);
            shieldCrystal.gameObject.SetActive(false);
            cameraFoll.player = GameObject.FindGameObjectWithTag("CameraPoint").transform;
            cameraZoomOut = true;
            gardenGnome3.gameObject.SetActive(false);            
        }
        if (cameraZoomOut && cameraZoomScale < 24.9f)
        {
            cameraZoomScale += Time.deltaTime;
            cameraFoll.cameraDistance = cameraZoomScale;            
        }
        if (isBuildingCrystal)
        {            
            if (shieldCrystal.GetComponent<BuildingCrystal>().buildTimer > 8f)
            {
                shieldCrystalLight.gameObject.SetActive(true);
                isBuildingCrystal = false;
            }
        }
        
        
    }
    public IEnumerator YieldCameraStart()
    {
        yield return new WaitForSeconds(3);
        startMovingCamera = true;
    }
    public IEnumerator YieldStart()
    {    
        yield return new WaitForSeconds(1);
        if (!startOnce)
        {
            startOnce = true;
        }
        else
        {
            cameraFoll.player = playerPosition.transform;
            startScene = true;
        }
    }
    public IEnumerator YieldTrigger()
    {
        yield return new WaitForSeconds(1);

        if (!trigger1)        
            trigger1 = true;        
        else        
            trigger2 = true;

        once = false;

    }
    public IEnumerator Yieldblackout()
    {
        yield return new WaitForSeconds(8);
        blackOut.startBlackOut = true;
        trigger5 = true;
    }
    public override State RunCurrentState()
    {
        return this;
    }

}