using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrystal : MonoBehaviour
{
    public Sprite[] crystalStates;
    public SpriteRenderer spriteRenderer;
    public ParticleSystem particle;
    bool once;
    public float buildTimer;
    public int i;
    
    public void BuildCrystal()
    {
        //spriteRenderer.sprite = crystalStates[i];
        //buildTimer += Time.deltaTime;
        //if (buildTimer < 1.5f)
        //{
        //    i = 0;            
        //    particle.Play();
        //}
        //else if (buildTimer < 3)
        //{
        //    i = 1;
        //    particle.Play();
        //}
        //else if (buildTimer < 4.5)
        //{
        //    i = 2;
        //    particle.Play();
        //}
        //else if (buildTimer < 6)
        //{
        //    i = 3;
        //    particle.Play();
        //}
        //else if (buildTimer < 7.5)
        //{
        //    i = 4;
        //    particle.Play();
        //}
    }
    public void ParticlePlay()
    {
        particle.Play();
    }
}
