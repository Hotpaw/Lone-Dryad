using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public void GameOver()
    {
        FindAnyObjectByType<Movement>().enabled = false;
        gameObject.SetActive(true);
    }
}
