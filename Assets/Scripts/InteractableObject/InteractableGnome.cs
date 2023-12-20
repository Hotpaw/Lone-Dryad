using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGnome : InteractableObject
{
    public override void Interact()
    {
        PopUpText.INSTANCE.PopUpMessage("The storm is coming!", Color.red, 12, PopUpText.Icon.Gnome);
        StartCoroutine(TalkingGnome());
    }

    private IEnumerator TalkingGnome()
    {
        yield return new WaitForSeconds(4);
        PopUpText.INSTANCE.PopUpMessage("Your tree will die in a short while if you do not repair the crystall", Color.red, 3, PopUpText.Icon.Gnome);
        yield return new WaitForSeconds(4);
        PopUpText.INSTANCE.PopUpMessage("Bring me seven crystallpieces, and i can help you!", Color.red, 3, PopUpText.Icon.Gnome);
    }
}


