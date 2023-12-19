using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    public Animator lightPuls;

    private void Start()
    {
        // Get the Animator component on the same GameObject.
        //lightPuls = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("here");
        // Check if the entering object is the player (you may want to use tags or layers).
        if (other.gameObject.CompareTag("Player"))
        {
            // Trigger the animation when the player enters the collider.
            lightPuls.SetBool("TriggerLight", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting object is the player (you may want to use tags or layers).
        if (other.gameObject.CompareTag("Player"))
        {
            lightPuls.SetBool("TriggerLight", false); //resetar triggern i animatorn
           
           
        }
    }


}
