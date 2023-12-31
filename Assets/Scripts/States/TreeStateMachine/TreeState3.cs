using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TreeState3 : State
{
    //Checking stuff
    public float distance;

    public static TreeState3 INSTANCE;
    public bool once;

    //Intro
    public GameObject[] revealParticles; 
    public GameObject swarm1;
    public GameObject cameraPoint2;
    public Transform cameraPoint2Target;
    public Transform triggerPoint;
    public bool getAllParticles;
    public bool startOnce;
    public bool startMovingCamera;
    public bool gnomeWentHome;
    public bool startScene;
    public float cameraMoveSpeed;
    
    public GameObject waterPosition;
    public GameObject playerPosition;
    public GameObject trigger2Position;
    public GameObject gardenGnome1;
    public GameObject swarmFront;
    public GameObject swarmBack;
    public GardenGnome2 gardenGnome2;   
    public cameraFollow cameraFoll;    
    
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
    public float buildTimer;
    public float crystalLightIntensity;
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
        FindAnyObjectByType<TreeScript>().GetComponent<Health>().HealToMax();
    }
    private void Update()
    {
        distance = Vector2.Distance(cameraPoint2.transform.position, triggerPoint.position);
        if (!startScene)
        {
            if (!getAllParticles)
            {
                revealParticles = GameObject.FindGameObjectsWithTag("RevealParticle");
                getAllParticles = true;
            }
            else
            {
                for (int i = 0; i < revealParticles.Length; i++)
                {
                    var emission = revealParticles[i].GetComponent<ParticleSystem>().emission;
                    emission.rateOverTime = 0;
                }
            }

            cameraPoint2Target.position = triggerPoint.position;
            cameraFoll.player = GameObject.FindGameObjectWithTag("CameraPoint2").transform;
            StartCoroutine(YieldCameraStart());
            if (startMovingCamera)
            {
                cameraPoint2.transform.position = Vector2.MoveTowards(cameraPoint2.transform.position, cameraPoint2Target.position, cameraMoveSpeed * Time.deltaTime);
                if (Vector2.Distance(cameraPoint2.transform.position, cameraPoint2Target.position) < 8 && !gnomeWentHome)
                {
                    gnomeWentHome = true;
                    gardenGnome1.GetComponent<Animator>().SetBool("GoingIn", true);
                    GameValueManager.INSTANCE.stormStrenght += 2;
                    swarmFront.GetComponent<Storm>().SetStormIntensity();
                    swarmBack.GetComponent<Storm>().SetStormIntensity();
                }
                if (!startScene && Vector2.Distance(cameraPoint2.transform.position, cameraPoint2Target.position) < 1f)  
                {
                    if (!startOnce)
                    {                        
                        StartCoroutine(YieldStart());
                        cameraPoint2Target.position = playerPosition.transform.position;
                        cameraMoveSpeed = 10;

                    }
                    if (startOnce)
                    {
                        StartCoroutine(YieldStart());
                        for (int i = 0; i < revealParticles.Length; i++)
                        {
                            var emission = revealParticles[i].GetComponent<ParticleSystem>().emission;
                            emission.rateOverTime = 10;
                        }
                    }
                }
            }
                          
        }        
        if (!trigger2)
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
            PopUpText.INSTANCE.PopUpMessage("My tree is in danger, I need to get rid of the enemies or my tree will be destroyed", Color.white, 3);
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
        if (isBuildingCrystal)
        {
            buildTimer += Time.deltaTime;
            shieldCrystalLight.gameObject.SetActive(true);
            shieldCrystalLight.GetComponent<Light2D>().intensity = crystalLightIntensity;
            if (buildTimer % 1 == 0) 
            {
                crystalLightIntensity += 0.4f;
            }
            if (buildTimer > 6f)
            {
                isBuildingCrystal = false;
                for (int i = 0; i < revealParticles.Length; i++)
                {
                    var emission = revealParticles[i].GetComponent<ParticleSystem>().emission;
                    emission.rateOverTime = 0;
                }
            }
        }
        if (cameraZoomOut && cameraZoomScale < 24.9f)
        {
            cameraZoomScale += Time.deltaTime;
            cameraFoll.cameraDistance = cameraZoomScale;
            if (cameraZoomScale > 24.5f)
                StartCoroutine(YieldNextStage());
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
        else if (!startScene)
        {
            cameraFoll.player = playerPosition.transform;
            startScene = true;
            Destroy(gardenGnome1);
            Destroy(swarm1);
            GameValueManager.INSTANCE.stormStrenght += 1;            
        }
    }
    public IEnumerator YieldTrigger()
    {
        yield return new WaitForSeconds(1);        
            trigger2 = true;

        once = false;

    }
    public IEnumerator Yieldblackout()
    {
        yield return new WaitForSeconds(8);
        blackOut.startBlackOut = true;
        trigger5 = true;
    }
    public IEnumerator YieldNextStage()
    {
        yield return new WaitForSeconds(5); 
        blackOut.startBlackOut = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);        
    }
    public override State RunCurrentState()
    {
        return this;
    }

}