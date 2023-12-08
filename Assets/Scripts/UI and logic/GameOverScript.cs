using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public static GameOverScript INSTANCE;
    public GameObject panel;

    public TextMeshProUGUI infoText;

    public void Awake()
    {
      
        INSTANCE = this;
        
    }

    public void GameOver()
    {
        if (!GameValueManager.INSTANCE.gameWon)
        {
            //FindAnyObjectByType<Movement>().enabled = false;
            panel.SetActive(true);
            infoText.text = "The Tree is rotten, you dead!\r\nPress R to restart";
        }
    }
    public void WinGame()
    {
        GameValueManager.INSTANCE.gameWon = true;
        //FindAnyObjectByType<Movement>().enabled = false;
        panel.SetActive(true);
        infoText.text = "The tree is healthy and happy! You won very much!\r\nPress R to restart";
    }
}
