using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class WiltingScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public new ParticleSystem particleSystem;
    public float wiltTimer = 1;
    bool wilting;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {        
        particleSystem.Play();
        WiltTree();          
        wilting = true;        
        if (wilting)
        {
            WiltTree();
        }        
    }
    //IEnumerator YieldWiltingTree()
    //{
    //    yield return new WaitForSeconds(2f);
    //    WiltTree();
    //}
    public void WiltTree()
    {
        //spriteRenderer.enabled = false;        
        wiltTimer -= (0.35f * Time.deltaTime);
        spriteRenderer.color = new Color(1, 1, 1, wiltTimer);
    }
}