using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WerewolfSummonstate : State
{
    bool done = false;
    bool hasSpawned = false;
    public override State RunCurrentState()
    {
        if (WereWolf.INSTANCE.moveToAttack)
        {
            return WereWolf.INSTANCE.IntroState;
        }
        if (!done)
        {
            done = true;
            StartCoroutine(summonbats());
        }
        if (done)
        {
            done = false;
            hasSpawned = false;
            return WereWolf.INSTANCE.IdleState;
        }
        return this;
    }



    IEnumerator summonbats()
    {
       
        WereWolf.INSTANCE.animator.SetTrigger("Howl");
        yield return new WaitForSeconds(WereWolf.INSTANCE.GetAnimationClipDuration("Werewolf_Howl")+ 1);
        EnemySpawner.INSTANCE.SpawnStage2();
        PopUpText.INSTANCE.PopUpMessage("The winged beasts return",Color.black);

     
        yield return new WaitForSeconds(1);
       
      
    }

}
