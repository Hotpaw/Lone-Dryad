using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableGnome : InteractableObject
{
    
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.thePowerToPickUpCrystals == false)
        {
            GameValueManager.INSTANCE.thePowerToPickUpCrystals = true;
            PopUpText.INSTANCE.PopUpMessage("The storm is coming!", Color.red, 12, PopUpText.Icon.Gnome);
            StartCoroutine(TalkingGnome());
        }
        if (GameValueManager.INSTANCE.numberOfCrystallPieces >= 7)
        {            
            PopUpText.INSTANCE.PopUpMessage("I will now repair the crystal for you!", Color.red, 5, PopUpText.Icon.Gnome);
            GameValueManager.INSTANCE.theShieldIsActive = true;
            FindAnyObjectByType<Storm>().IncreaseStormIntensity();
            FindAnyObjectByType<Storm>().IncreaseStormIntensity();
        }
    }

    private IEnumerator TalkingGnome()
    {
        yield return new WaitForSeconds(3);
        PopUpText.INSTANCE.PopUpMessage("Your tree will die in a short while if you do not repair the crystall", Color.red, 3, PopUpText.Icon.Gnome);
        yield return new WaitForSeconds(4);
        PopUpText.INSTANCE.PopUpMessage("Bring me seven crystallpieces, and i will help you!", Color.red, 3, PopUpText.Icon.Gnome);

    }
}


