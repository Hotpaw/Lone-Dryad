using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class WiltingScript : MonoBehaviour
{
    public List<Sprite> treeStages;
    SpriteRenderer spriteRenderer;    
    public new ParticleSystem particleSystem;
    public float wiltTimer = 1;
    public int id;
    bool wilting;
    bool once;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();             
    }

    private void Update()
    {   
        if (!once) 
            particleSystem.Play();
        once = true;
        WiltTree();          
        wilting = true;        
        if (wilting)
        {
            WiltTree();
        }        
    }    
    public void WiltTree()
    {           
        wiltTimer -= (0.35f * Time.deltaTime);
        spriteRenderer.color = new Color(1, 1, 1, wiltTimer);
    }   
}