using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition3 : MonoBehaviour
{

    public Image transition;

    public Animator anim;

    public void Start()
    {
        //anim.gameObject.SetActive(true);
        //anim = GetComponent<Animator>();
        anim.SetBool("Fade", false); //se till att faden är falsk i  början, annars blir skärmen svart. 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Play"))
        {
            anim.SetTrigger("Start"); 
        }
        if (Input.GetButtonDown("Settings"))
        {
            anim.SetTrigger("Start"); //starta trigger animationen.  // Trigger the 'Start' parameter to initiate transitions in the Animator
            //SetTrigger("Start"), sets the value of the trigger named "Start" to true for that frame. It's a momentary signal that indicates a specific event.
            //retuernerar false efter en frame. 
        }
        if (Input.GetButtonDown("Credits"))
        {
            anim.SetTrigger("Start");
            Debug.Log("credit buttton");


        }
        if (Input.GetButtonDown("Quit"))
        {
            anim.SetTrigger("Start"); 

        }
       
        if (Input.GetButtonDown("Back"))
        {
            anim.SetTrigger("Start");
            Debug.Log("Backbutton");
        }

        //Invoke("LoadSceneWithTransition", 2f);

    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutLoadScene((sceneName)));
    }
    public IEnumerator FadeOutLoadScene(string sceneName)
    {
        anim.SetBool("Fade", false); //trigga fade out anim genom att sätta fade in på false
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);  //kollar om animationen har kört slut/klart innan den gör nästa fade

    }

    //public  void LoadSceneWithTransition(string sceneName)
    //{

    //    SceneManager.LoadScene("Play"); //ladda ny scene
    //    SceneManager.LoadScene("Settings"); //ladda ny scene
    //    SceneManager.LoadScene("Credits"); //ladda ny scene
    //    //SceneManager.LoadScene("Quit"); //ladda ny scene

    //}
}
