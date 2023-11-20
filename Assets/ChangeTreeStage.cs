using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeTreeStage : MonoBehaviour
{
    public List<Sprite> treeStages;
    SpriteRenderer spriteRenderer;
    public ParticleSystem particleSystem;
    int id =2;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame == true)
        {
            ChangeTreeSprite(id);
            id++;     
            particleSystem.Play();
        }
        
    }
    public void ChangeTreeSprite(int id)
    {
        switch (id)
        {
            case 2: spriteRenderer.sprite = treeStages[0];
                break;
            case 3:
                spriteRenderer.sprite = treeStages[1];
                break;
            case 4:
                spriteRenderer.sprite = treeStages[2];
                break;
        }
    }
}
