using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableGnome : InteractableObject
{
    public Animator animator;
    
    public override void Interact()
    {
        if (GameValueManager.INSTANCE.thePowerToPickUpCrystals == false)
        {
            animator.SetBool("Talking", true);
            GameValueManager.INSTANCE.stormStrenght++;
            

            PopUpText.INSTANCE.PopUpMessage("The swarm is coming!", Color.red, 12, PopUpText.Icon.Gnome);
            StartCoroutine(TalkingGnome());
        }
        else if (GameValueManager.INSTANCE.thePowerToPickUpCrystals == true && GameValueManager.INSTANCE.numberOfCrystallPieces < 7)
        {
            animator.SetBool("Talking", true);
            PopUpText.INSTANCE.PopUpMessage("Why are you wasting time here? You have to find " 
                + (7 - GameValueManager.INSTANCE.numberOfCrystallPieces) + " more crystal pieces!", Color.red, 5, PopUpText.Icon.Gnome);
            StartCoroutine(StopTalkingGnome());
        }
        else if (GameValueManager.INSTANCE.numberOfCrystallPieces >= 7)
        {
            animator.SetBool("Talking", true);
            PopUpText.INSTANCE.PopUpMessage("I will now repair the crystal for you!", Color.red, 5, PopUpText.Icon.Gnome);
            GameValueManager.INSTANCE.theShieldIsActive = true;
            GameValueManager.INSTANCE.stormStrenght += 2;
            GameValueManager.INSTANCE.nextLevelAvailable = true;
            TreeState3.INSTANCE.trigger4 = true;
        }
    }

    private IEnumerator TalkingGnome()
    {
        yield return new WaitForSeconds(3);
        GameValueManager.INSTANCE.thePowerToPickUpCrystals = true;
        PopUpText.INSTANCE.PopUpMessage("You need to repair the crystal or your tree will perish soon", Color.red, 3, PopUpText.Icon.Gnome);
        yield return new WaitForSeconds(4);
        PopUpText.INSTANCE.PopUpMessage("If you bring me seven crystal pieces, I will be able to repair it for you", Color.red, 3, PopUpText.Icon.Gnome);
        animator.SetBool("Talking", false);

    }
    private IEnumerator StopTalkingGnome()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("Talking", false);
    }

}


