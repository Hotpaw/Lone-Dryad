using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Health health;    
    public GameObject wiltingTree;    

    void Update()
    {           
        if (health.currentHealth == health.maxHealth)
            GameValueManager.INSTANCE.IncreaseProgress();
    }
    public void WiltingTree()
    {
        wiltingTree.SetActive(true);
        GameOverScript.INSTANCE.GameOver();
    }
}
