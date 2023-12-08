using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValueManager : MonoBehaviour
{
    public static GameValueManager INSTANCE;

    //Tree Stats    
    public float progressScore;
    public float nextStageScore;    
    public float treeLevel;
    public bool treeIsALive = true;
    public bool gameWon;
    public int sceneNr;

    //Dryad stats
    public TeleportScript teleportScript;    

    public bool gotWater;
    public bool addingWater;

    //Unlockable stats
    public bool thePowerToThrowNuts;

    [HideInInspector] public bool KC;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void IncreaseProgress()
    {        
        progressScore += 1f * Time.deltaTime;
        if (progressScore >= nextStageScore)
        {
            SceneLoader.INSTANCE.LoadScene(sceneNr + 1);
        }
    }    
}