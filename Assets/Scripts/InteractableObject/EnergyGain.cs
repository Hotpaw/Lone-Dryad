using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGain : InteractableObject
{
    public float amount;
    public override void Interact()
    {
        //GameValueManager.INSTANCE.IncreaseEnergyLevel(amount);
        PopUpText.INSTANCE.PopUpMessage(amount.ToString() + " Energy Gained",Color.white);
    }

  
}
