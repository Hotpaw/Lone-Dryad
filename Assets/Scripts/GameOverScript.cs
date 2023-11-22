using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public void GameOver()
    {
        FindAnyObjectByType<Movement>().enabled = false;
        gameObject.SetActive(true);
        infoText.text = "The Tree is rotten, you dead!\r\nPress R to restart";
    }
    public void WinGame()
    {
        FindAnyObjectByType<Movement>().enabled = false;
        gameObject.SetActive(true);
        infoText.text = "The tree is healthy and happy! You won very much!\r\nPress R to restart";
    }
}
