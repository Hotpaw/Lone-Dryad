using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSwitch : InteractableObject
{
    public int mode = 0;
    public override void Interact()
    {
        if (cullBackground.INSTANCE.Backgrounds[0].activeInHierarchy)
        {
            if(mode == 0)
            {

            cullBackground.INSTANCE.CullingModeCall(1);
            }
            if(mode == 1)
            {
                cullBackground.INSTANCE.CullingModeCall(2);
            }
        }
        else
        {
            cullBackground.INSTANCE.CullingModeCall(0);
        }
      
    }

    
}
