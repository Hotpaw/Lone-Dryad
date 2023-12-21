using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollow : MonoBehaviour
{
    public float cameraDistance;
    Vector3 playerPosition;    
    Camera[] cameras;
    // Start is called before the first frame update

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Stage3.1")
        {
            cameraDistance = 15;
        }
        else if (SceneManager.GetActiveScene().name != "EndStage")
        {
            cameraDistance = 11;
        }
        cameras = FindObjectsOfType<Camera>();

        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = cameraDistance;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (playerPosition != null)
        {
            playerPosition = new Vector3(FindAnyObjectByType<Movement>().transform.position.x, FindAnyObjectByType<Movement>().transform.position.y, -10);
            transform.position = playerPosition;
        }        

    }
    public void ZoomOutNow()
    {
        cameras = FindObjectsOfType<Camera>();

        cameraDistance = 18;

        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = cameraDistance;
        }
    }
}


