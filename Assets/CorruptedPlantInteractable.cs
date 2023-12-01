using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorruptedPlantInteractable : InteractableObject
{
    public GameObject amuletGlow;

    public void Start()
    {
        amuletGlow = GameObject.FindGameObjectWithTag("Amulet");
    }

    public override void Interact()
    {
        amuletGlow.GetComponent<ParticleSystem>().Play(); 
    }   
}
