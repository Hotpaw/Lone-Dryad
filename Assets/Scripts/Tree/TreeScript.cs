using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Health health;    
    public GameObject wiltingTree;    
    
    public void WiltingTree()
    {
        wiltingTree.SetActive(true);
        GameOverScript.INSTANCE.GameOver();
    }
}
