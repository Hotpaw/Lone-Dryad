using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGnome : InteractableObject
{
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("The storm is coming!", Color.red, 4);
        StartCoroutine(TalkingGnome());
    }

    private IEnumerator TalkingGnome()
    {
        yield return new WaitForSeconds(4);
        PopUpText.INSTANCE.PopUpMessage("Your tree will die in a short while if you do not repair the crystall", Color.red, 4);
        yield return new WaitForSeconds(4);
        PopUpText.INSTANCE.PopUpMessage("Bring me seven crystallpieces, and i can help you!", Color.red, 4);
    }
}


