using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ChangeTreeStage : MonoBehaviour
{
    public List<Sprite> treeStages;
    SpriteRenderer spriteRenderer;
    public new ParticleSystem particleSystem;
    public int id =1;
    bool once;    
    public GameOverScript gameOverScript;
    public Collider2D branchOne;
    public Collider2D branchTwo;    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystem.Play();
        GameValueManager.INSTANCE.nextStageScore = 60;
    }
    private void Update()
    {
        //GameValueManager.INSTANCE.IncreaseProgress();
        var emission = particleSystem.emission;
        if (!once)
            emission.rateOverTime = id * 0.35f * GameValueManager.INSTANCE.progressScore;
        var shape = particleSystem.shape;

        if(Keyboard.current.gKey.wasPressedThisFrame == true || GameValueManager.INSTANCE.progressScore >= GameValueManager.INSTANCE.nextStageScore)
        {   
            if (!once && id < 6)
            {
                Destroy(GetComponent<PolygonCollider2D>());
                once = true;
                GameValueManager.INSTANCE.treeLevel++;
                Water.INSTANCE.waterAmount = 50;
                id++;
                shape.randomDirectionAmount = 1;
                shape.randomPositionAmount = 1;
                shape.sphericalDirectionAmount = 1;
                emission.rateOverTime = id * 2000;                
                StartCoroutine(YieldChangeTreeSprite());                
            }
        } 
    }
    IEnumerator YieldChangeTreeSprite()
    {
        yield return new WaitForSeconds(1f);
        ChangeTreeSprite(id);
        var shape = particleSystem.shape;
        shape.randomDirectionAmount = 0;
        shape.randomPositionAmount = 0;
        shape.sphericalDirectionAmount = 0;
        GameValueManager.INSTANCE.progressScore = 0;
        GameValueManager.INSTANCE.nextStageScore = 80 * (id * 0.5f);
        gameObject.AddComponent<PolygonCollider2D>();
        once = false;
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
                branchOne.enabled = true;
                branchTwo.enabled = true;
                break;
            case 5:
                spriteRenderer.sprite = treeStages[4];   
                break;
            case 6:
                spriteRenderer.sprite = treeStages[4];
                gameOverScript.WinGame();
                break;
        }
    }
    
}
