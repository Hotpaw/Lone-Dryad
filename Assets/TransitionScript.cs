using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
   
    public Animator transition;
    public float transitionTime;
    Menu menuScript;

    private void Awake()
    {
        menuScript = FindAnyObjectByType<Menu>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (menuScript != null) 
        //{
        
        //  if (menuScript.PlayGame())
        //  {

        //        SceneTransition();
        //  }
        
        //}
        //else
        //{
        //    Debug.LogError("MenuScript not found");
        //}

        if (Input.GetMouseButtonDown(0))
        {
            SceneTransition();
        }

    }

    public void SceneTransition()
    {
        //SceneManager.LoadScene("Andre");
        StartCoroutine(LoadScene((SceneManager.GetActiveScene().buildIndex + 1)));
       
    }
    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("start");               //which animation clip trigger to play
        yield return new WaitForSeconds(transitionTime);  //load scene time
        SceneManager.LoadScene(sceneIndex);             //which scene to load
    }
}
