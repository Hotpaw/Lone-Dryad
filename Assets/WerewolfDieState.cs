using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WerewolfDieState : State
{
    public GameObject stopGrowling;

    bool used = true;
    public override State RunCurrentState()
    {
        if (used)
        {
            used = false;
            GameValueManager.INSTANCE.nextLevelAvailable = true;
            PopUpText.INSTANCE.PopUpMessage("Finally, i am safe. Now i can rest...",Color.white);
            stopGrowling.SetActive(false);
            StartCoroutine(endScene());
            return this;

        }

        else return this;
        throw new System.NotImplementedException();
    }
    IEnumerator endScene()
    {
        blackOut blackout = FindObjectOfType<blackOut>();
        blackout.startBlackOut = true;
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);
    }

}
