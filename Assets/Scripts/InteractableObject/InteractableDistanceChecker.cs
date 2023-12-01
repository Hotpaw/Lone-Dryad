using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableDistanceChecker : InteractableObject
{
    bool triggered;

    public override void Interact()
    {
        if (!triggered)
        {
            PopUpText.INSTANCE.PopUpMessage("I am feeling weaker", Color.gray);     
            GameValueManager.INSTANCE.IncreaseExhaustLevel();
        }
        if (triggered)
        {
            PopUpText.INSTANCE.PopUpMessage("I am feeling stronger", Color.gray);
            GameValueManager.INSTANCE.DecreaseExhaustLevel();
        }
        triggered = !triggered;
    }

}

