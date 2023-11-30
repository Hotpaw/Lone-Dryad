using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.carryingWater > 0)
        {
            FindObjectOfType<Movement>().gameObject.GetComponent<Animator>().SetTrigger("Walk");
            GameValueManager.INSTANCE.waterLevel += GameValueManager.INSTANCE.carryingWater;
            PopUpText.INSTANCE.PopUpMessage("Drunk tree", Color.magenta);
            if (GameValueManager.INSTANCE.waterLevel > 100)
                GameValueManager.INSTANCE.waterLevel = 100;
            GameValueManager.INSTANCE.carryingWater = 0;
        }
    }
}
