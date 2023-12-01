using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public static GameOverScript INSTANCE;

    public TextMeshProUGUI infoText;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void GameOver()
    {
        if (!GameValueManager.INSTANCE.gameWon)
        {
            FindAnyObjectByType<Movement>().enabled = false;
            gameObject.SetActive(true);
            infoText.text = "The Tree is rotten, you dead!\r\nPress R to restart";
        }
    }
    public void WinGame()
    {
        GameValueManager.INSTANCE.gameWon = true;
        FindAnyObjectByType<Movement>().enabled = false;
        gameObject.SetActive(true);
        infoText.text = "The tree is healthy and happy! You won very much!\r\nPress R to restart";
    }
}
