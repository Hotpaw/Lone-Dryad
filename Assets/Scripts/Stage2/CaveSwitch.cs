using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSwitch : InteractableObject
{
    public override void Interact()
    {
        if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)
        {
            cullBackground.INSTANCE.CullingModeCall(1);
        }
        else
        {
            cullBackground.INSTANCE.CullingModeCall(0);
        }
      
    }

    
}
