using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition2 : MonoBehaviour
{

    [SerializeField] public GameObject startTransition;
    [SerializeField] public GameObject endTransition;
    [SerializeField] private float transitionDuration = 5f;
    float loadDuration = 1.5f;


    public void Start()
    {

        startTransition.SetActive(true);
        Invoke("DisableStartTransition", transitionDuration); //vänta 5 sek, sen kalla funktionen
    }
   
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0));
        {
          
            endTransition.SetActive(true);
            Invoke("LoadNextScene", loadDuration);
        }
        
    }

    public void DisableStartTransition()
    {
        startTransition.SetActive(false);
    }
    public void LoadNextScene()
    {
            SceneManager.LoadScene("Credits");

    }
}
