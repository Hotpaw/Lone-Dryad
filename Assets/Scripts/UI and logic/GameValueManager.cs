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
    public float currentEnergy;
    public float maxHealth;
    public float currentHealth;
    

    public bool treeIsALive = true;
    public bool gameWon;

    //Dryad stats
    public TeleportScript teleportScript;
    public float carryingWater;
    public float carryingWaterMax;
    public float exhaustLevel;
    public float maxExhaustLevel;
    public bool Crawl;
    public Animator animator;

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
    
    public void IncreaseEnergyLevel(float amount)
    {
        currentEnergy += amount;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }
    public void GameOver()
    {

    }

}