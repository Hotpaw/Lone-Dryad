using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Health health;    
    public GameObject wiltingTree;
    float dryingColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown (KeyCode.LeftControl)) 
        {
            health.TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            health.Heal(1);
        }
        if (health.currentHealth <= 0 && !GameValueManager.INSTANCE.gameWon)
            WiltingTree();
        if (GameValueManager.INSTANCE?.waterLevel <= 0) 
        {                       
            StartCoroutine(health.YieldDie());
            WiltingTree();
        }
    }
    public void WiltingTree()
    {
        wiltingTree.SetActive(true);
        GameOverScript.INSTANCE.GameOver();
    }
}
