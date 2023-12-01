using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Health health;
    public GameOverScript gameOverScript;
    public GameObject wiltingTree;
    float dryingColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        dryingColor = GameValueManager.INSTANCE.waterLevel * 0.01f;
        GameValueManager.INSTANCE?.IncreaseProgress();
        GameValueManager.INSTANCE?.LoseWater();
        spriteRenderer.color = new Color(dryingColor, dryingColor, dryingColor, 1);
        if (Input.GetKeyDown (KeyCode.LeftControl)) 
        {
            health.TakeDamage(1);
        }
        if (health.currentHealth <= 0 && !GameValueManager.INSTANCE.gameWon)
            WiltingTree();
        if (GameValueManager.INSTANCE?.waterLevel <= 0) 
        {           
            gameOverScript.GameOver();
            StartCoroutine(health.YieldDie());
            WiltingTree();
        }
    }
    public void WiltingTree()
    {
        wiltingTree.SetActive(true);
        gameOverScript.GameOver();
    }
}
