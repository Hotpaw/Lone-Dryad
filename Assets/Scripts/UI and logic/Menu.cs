using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Update()
    {
        if(Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
        {
            PlayGame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Stage1.1");
       
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void BackToGame()  //tillbaka till spelet knapp efter man gått in på settings
    {
        SceneManager.LoadScene("Stage1.1");
    }
    //public void EscapeButton()
    //{
        
    //    if (Input.GetKey(KeyCode.Escape)) 
    //    {
    //      SceneManager.LoadScene("MainMenu"); //esc knapp till menu
    //    }
    //}


    public void QuiteGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
