using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterSound : MonoBehaviour
{

    AudioSource water;
    Collider2D waterTrigger;

    private void Awake()
    {
        water = GetComponent<AudioSource>();
        waterTrigger = GetComponent<Collider2D>();
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        water.Play();

        
    }
}
