using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSanta : MonoBehaviour
{

    [SerializeField] private Animator triggerSanta;
    private bool santaTriggered = false;


    private void OnCollisionEnter2D(Collision2D other)
    {

       if (other.gameObject.CompareTag ("Player") && !santaTriggered)
       {
        triggerSanta.SetBool("name of animation", true); 
            santaTriggered = true;
       }


    }

    //private void OnCollisionExit2D(Collision2D other)
    //{

    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        triggerSanta.SetBool("name of animation", false);
    //    }


    //}


  
}
