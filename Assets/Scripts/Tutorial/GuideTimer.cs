using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTimer : MonoBehaviour
{
    public static GuideTimer INSTANCE;

    //Triggers
    public int guideTrigger;
    public bool canStartGuide;
    public bool guideIsActive;

    public float guideTimer;
    public SpriteRenderer spriteRenderer;
    ParticleSystem particleSystem;

    public Transform[] guidePoints;
    public Transform activeGuidePoint;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
        
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        spriteRenderer.enabled = false;
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        guideTimer += Time.deltaTime;

        if(guideTimer > 120) 
        {
            canStartGuide = true;
            PopUpText.INSTANCE.PopUpMessage("I can go to my tree and ask the spirits for help", Color.white, 3);
            spriteRenderer.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, activeGuidePoint.position, 2 * Time.deltaTime);
            particleSystem.Play();
        }
        else
        {
            spriteRenderer.enabled = false;
            transform.position = player.position;
            particleSystem.Stop();
        }
    }
    public void NextGuidePoint()
    {
        guideTimer = 0;
        activeGuidePoint = guidePoints[guideTrigger];
    }
}
