using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorruptedPlantInteractable : InteractableObject
{    
    public GameObject amuletGlow;
    public PlantScript plantScript;

    public void Start()
    {
        amuletGlow = GameObject.FindGameObjectWithTag("Amulet");
    }

    public override void Interact()
    {        
        if (amuletGlow != null)
            amuletGlow.GetComponent<ParticleSystem>().Play();
        plantScript.KillPlant();        
    }   
}
