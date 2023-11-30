using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorruptedPlantInteractable : InteractableObject
{
    public override void Interact()
    {
       Destroy(gameObject);
    }

   
}
