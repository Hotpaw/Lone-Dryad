using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeState5 : State
{
    public static TreeState5 INSTANCE;
    bool once;
    public Animator wereWolfEyes;
   public GameObject caveleft;
    public void Start()
    {
        PopUpText.INSTANCE.PopUpMessage("The water is Gone, i should climb the branches to find out what happened", Color.black, 5f);
        INSTANCE = this;

    }
    public override State RunCurrentState()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            ActivateWereWolfEvent();
        }
        return this;

    }
    public void ActivateWereWolfEvent()
    {
        StartCoroutine(WereWolfEvent());
    }
    public void NextLevel()
    {
        GameValueManager.INSTANCE.nextLevelAvailable = true;
    }
    IEnumerator WereWolfEvent()
    {
        blackOut blackout = FindObjectOfType<blackOut>();
        blackout.startBlackOut = true;
        yield return new WaitForSeconds(3);
        cameraFollow cam = FindObjectOfType<cameraFollow>();
        cam.transform.position = wereWolfEyes.gameObject.transform.position;
        caveleft.SetActive(true);
       
        wereWolfEyes.SetTrigger("EyeTrigger");
        blackout.startBlackOut = true;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);

    }
}