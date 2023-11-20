using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public float progressScore;
    public float health;
    public float waterLevel;
    public float waterLoss;
    public float treeLevel;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waterLevel -= (waterLoss - treeLevel) * Time.deltaTime;
        spriteRenderer.color = new Color(1, 1, 1, waterLevel * 0.01f);        
    }
}
