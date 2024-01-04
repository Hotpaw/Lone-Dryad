using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class GameValueManager : MonoBehaviour
{
    public static GameValueManager INSTANCE;

    //Tree Stats    
    public float progressScore;
    public float nextStageScore;
    public bool progressActive;
    public float treeLevel;
    public bool treeIsALive = true;
    public bool gameWon = false;
    public bool gameLost = false;
    public int sceneNr;
    public bool nextLevelAvailable;
    
    //Dryad stats
    public TeleportScript teleportScript;    

    public bool gotWater;
    public bool addingWater;

    //Unlockable stats
    public bool thePowerToThrowNuts;
    public bool thePowerToPlant;
    public bool thePowerToPickUpCrystals;
    public bool theShieldIsActive;
    public int stones;
    public int maxStones;
    public int numberOfCrystallPieces;
    public int maxNumberOfCrystallPieces = 7;

    public int currentsceneBuildIndex;

    //Storm stats
    public float stormStrenght;
    [HideInInspector] public bool KC;
    //Post Processing
    public Volume postProcessingVolume;
    Bloom bloomEffect = null;
    public void Awake()
    {
        Cursor.visible = false;
        
        currentsceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
       
        INSTANCE = this;
        //if (postProcessingVolume.profile.TryGet<Bloom>(out bloomEffect))
        //{
        //    // Bloom effect is accessible now
        //}
    }
    public void SetBloomIntensity(float intensity)
    {
        if (bloomEffect != null)
        {
            bloomEffect.intensity.Override(intensity);
        }
    }
    public void IncreaseProgress()
    {
        if (progressActive)
        {
            progressScore += 10;
        }        
        if (progressScore >= nextStageScore)
        {
            nextLevelAvailable = true;
            PopUpText.INSTANCE.PopUpMessage("My tree is doing well now, i can go back and sleep for a couple of years", Color.green, 5);            
        }
    }    
}