using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeTreeStage : MonoBehaviour
{
    public List<Sprite> treeStages;
    SpriteRenderer spriteRenderer;
    public new ParticleSystem particleSystem;
    int id =1;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Keyboard.current.gKey.wasPressedThisFrame == true || GameValueManager.INSTANCE.progressScore >= 100)
        {            
            id++;     
            particleSystem.Play();
            StartCoroutine(YieldChangeTreeSprite());
            GameValueManager.INSTANCE.progressScore = 0;
        }
        
    }
    IEnumerator YieldChangeTreeSprite()
    {
        yield return new WaitForSeconds(1f);
        ChangeTreeSprite(id);
    }
    public void ChangeTreeSprite(int id)
    {
        switch (id)
        {
            case 1:
                spriteRenderer.sprite = treeStages[0];
                break;
            case 2: spriteRenderer.sprite = treeStages[1];
                break;
            case 3:
                spriteRenderer.sprite = treeStages[2];
                break;
            case 4:
                spriteRenderer.sprite = treeStages[3];
                break;
        }
    }
    
}
