using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValueManager : MonoBehaviour
{
    public static GameValueManager INSTANCE;

    //Tree Stats    
    public float progressScore;
    public float nextStageScore;
    public float waterLevel;
    public float waterLoss;
    public float treeLevel;
    public bool treeIsALive = true;
    public bool gameWon;

    //Dryad stats
    public TeleportScript teleportScript;
    public float carryingWater;
    public float carryingWaterMax;

    public bool addingWater;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void IncreaseProgress()
    {
        if (waterLevel > 75)
        {
            progressScore += 1f * Time.deltaTime;
        }
        else if (waterLevel > 50)
        {
            progressScore += 0.75f * Time.deltaTime;
        }
        else if (waterLevel > 0)
        {            
            progressScore += 0.5f * Time.deltaTime;
        }
        else if (waterLevel <= 0)
        {
            progressScore -= 1f * Time.deltaTime;
            waterLevel = 0;
        }
    }

    public void LoseWater()
    {
        waterLevel -= (waterLoss - treeLevel) * Time.deltaTime;   
    }    
}