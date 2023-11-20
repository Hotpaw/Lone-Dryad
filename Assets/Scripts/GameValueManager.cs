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
    public float carryingWater;
    public float exhaustLevel;

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
    }
    
}