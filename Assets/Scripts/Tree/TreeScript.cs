using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Health health;
    public GameOverScript gameOverScript;
    public GameObject wiltingTree;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GameValueManager.INSTANCE?.LoseWater();
        spriteRenderer.color = new Color(1, 1, 1, GameValueManager.INSTANCE.waterLevel * 0.01f);
        if (Input.GetKeyDown (KeyCode.LeftControl)) 
        {
            health.TakeDamage(1);
        }
        if (health.currentHealth <= 0)
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
