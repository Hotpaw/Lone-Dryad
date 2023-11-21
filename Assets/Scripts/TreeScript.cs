using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GameValueManager.INSTANCE?.LoseWater();
        //spriteRenderer.color = new Color(1, 1, 1, GameValueManager.INSTANCE.waterLevel * 0.01f);        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        health.TakeDamage(1);
    }

}
