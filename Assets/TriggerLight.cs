using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerLight : MonoBehaviour
{
    public Animator lightPuls;

    public Light2D light2D;

    private void Start()
    {
        
        //lightPuls = GetComponentInParent<Animator>();
        light2D.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            // setter bool till true när playern är inom trigger området. 
            lightPuls.SetBool("TriggerLight", true);
            light2D.enabled=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            lightPuls.SetBool("TriggerLight", false); //resetar triggern i animatorn
            light2D.enabled=false;
           
           
        }
    }


}
