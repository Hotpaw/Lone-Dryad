using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevButtonScript : MonoBehaviour
{
    public GameObject player;
    public Vector2 checkPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.C))
            checkPoint = player.transform.position;
        if (Input.GetKeyDown(KeyCode.T))
            player.transform.position = checkPoint;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Time.timeScale -= 0.25f;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Time.timeScale += 0.25f;
    }
}
