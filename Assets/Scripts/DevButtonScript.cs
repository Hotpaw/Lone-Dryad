using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevButtonScript : MonoBehaviour
{
    public GameObject player;
    public Vector2 checkPoint;
    public float playerY;
    public float playerX;
    // Start is called before the first frame update
    void Start()
    {
        playerY = PlayerPrefs.GetFloat("PlayerY");
        playerX = PlayerPrefs.GetFloat("PlayerX");
        player.transform.position = new Vector2(playerX, playerY);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.Save();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            playerY = PlayerPrefs.GetFloat("PlayerY");
            playerX = PlayerPrefs.GetFloat("PlayerX");
            player.transform.position = new Vector2(playerX, playerY);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Time.timeScale -= 0.25f;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Time.timeScale += 0.25f;
    }
}
