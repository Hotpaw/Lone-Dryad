using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValueManager : MonoBehaviour
{
    public static GameValueManager INSTANCE;

    //Tree Stats    
    public float progressScore;    
    public float waterLevel;
    public float waterLoss;
    public float treeLevel;

    //Dryad stats
    public TeleportScript teleportScript;
    public float carryingWater;
    public float exhaustLevel;
    public float maxExhaustLevel;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoseWater()
    {
        waterLevel -= (waterLoss - treeLevel) * Time.deltaTime;
    }

    public void IncreaseExhaustLevel()
    {
        exhaustLevel++;
        if (exhaustLevel >= maxExhaustLevel) 
        {
            teleportScript.TeleportBackToTree();
            exhaustLevel = 0;
        }
    }
    
}