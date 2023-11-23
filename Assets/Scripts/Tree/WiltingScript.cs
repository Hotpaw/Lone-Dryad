using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class WiltingScript : MonoBehaviour
{
    public List<Sprite> treeStages;
    SpriteRenderer spriteRenderer;
    public ChangeTreeStage changeTreeStage;
    public new ParticleSystem particleSystem;
    public float wiltTimer = 1;
    public int id;
    bool wilting;
    bool once;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
        ChangeTreeSprite(changeTreeStage.id);       
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
    public void ChangeTreeSprite(int id)
    {
        switch (id)
        {
            case 1:
                spriteRenderer.sprite = treeStages[0];
                break;
            case 2:
                spriteRenderer.sprite = treeStages[1];
                break;
            case 3:
                spriteRenderer.sprite = treeStages[2];
                break;
            case 4:
                spriteRenderer.sprite = treeStages[3];
                break;
            case 5:
                spriteRenderer.sprite = treeStages[4];
                break;            
        }
    }
}