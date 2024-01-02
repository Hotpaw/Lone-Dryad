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
    public GameObject background;
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
        yield return new WaitForSeconds(1.7f);
        cameraFollow cam = FindObjectOfType<cameraFollow>();
        cam.player = wereWolfEyes.gameObject.transform;
        background.SetActive(false);
        caveleft.SetActive(true);
        yield return new WaitForSeconds(2);
        wereWolfEyes.SetTrigger("EyeTrigger");
        blackout.endBlackOut = false;
        blackout.startBlackOut = true;
        blackout.fadeSpeed = 3f;
        yield return new WaitForSeconds(3);
       
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(GameValueManager.INSTANCE.currentsceneBuildIndex + 1);

    }
}