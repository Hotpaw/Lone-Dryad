using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeState3 : State
{
    public static TreeState3 INSTANCE;
    public bool once;
    
    public int numberOfCrystallPieces;
    public int maxCrystals;    
    public GameObject waterPosition;
    public GameObject playerPosition;
    public GameObject trigger2Position;
    public GardenGnome1 gardenGnome;
    public GardenGnome2 gardenGnome2;
    public cameraFollow cameraFoll;
    
    public bool trigger1;
    public bool trigger2;
    public bool trigger3;
    
    public float checkDist;
    public float checkDist2;

    //For ending
    public blackOut blackOut;
    public bool trigger4;
    public bool trigger5;    
    public bool once2;
    public bool once3;
    public bool once4;
    public bool cameraZoomOut;
    public float cameraZoomScale;
    public GameObject cavefull;
    public GameObject background;
    public GameObject caveleft;
    public GameObject shieldCrystalLight;
    public GameObject gardenGnome3;

    public void Start()
    {
        GameValueManager.INSTANCE.progressActive = false;
        INSTANCE = this;
        cameraZoomScale = cameraFoll.cameraDistance;
    }
    private void Update()
    {
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
            GameValueManager.INSTANCE.stormStrenght +=2;
            trigger3 = true;
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
            GameValueManager.INSTANCE.stormStrenght += 5;
            once3 = true;
            cavefull.gameObject.SetActive(true);
            shieldCrystalLight.gameObject.SetActive(true);
            background.gameObject.SetActive(false);

            playerPosition.transform.position = new Vector3(55.5f, -11f);
            gardenGnome3.gameObject.SetActive(true);
            StartCoroutine(Yieldblackout());
        }
        if (trigger5 && blackOut.fadedTime > 1 && !once4)
        {

            once4 = true;
            background.gameObject.SetActive(true);
            cavefull.gameObject.SetActive(false);
            caveleft.gameObject.SetActive(false);
            shieldCrystalLight.gameObject.SetActive(false);
            cameraFoll.player = GameObject.FindGameObjectWithTag("CameraPoint").transform;
            cameraZoomOut = true;
        }
        if (cameraZoomOut && cameraZoomScale < 24.9f)
        {
            cameraZoomScale += Time.deltaTime;
            cameraFoll.cameraDistance = cameraZoomScale;
            if (cameraZoomScale >= 25 ) 
            {
                cameraZoomScale = 25;
            }
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
        yield return new WaitForSeconds(5);
        blackOut.startBlackOut = true;
        trigger5 = true;
    }
    public override State RunCurrentState()
    {
        return this;
    }

}