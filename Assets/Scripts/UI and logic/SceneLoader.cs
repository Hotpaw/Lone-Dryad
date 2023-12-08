using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader INSTANCE;

    public void Awake()
    {
     
        INSTANCE = this;
      
    }

    public void LoadScene(int scene)
    {
        switch (scene)
        {
            case 0:
                {
                    SceneManager.LoadScene("MainMenu");
                    break;
                }
            case 1:
                {
                    SceneManager.LoadScene("Stage1.1");
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene(2);
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene("Credits");
                    break;
                }
        }
    }
}
