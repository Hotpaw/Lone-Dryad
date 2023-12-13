using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float cameraDistance;
    Vector3 playerPosition;
    Camera[] cameras;
    // Start is called before the first frame update

    private void Start()
    {
        if (Application.isEditor)
        {
            cameras = FindObjectsOfType<Camera>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Application.isEditor)
        {
           foreach(Camera cam in cameras)
            {
                cam.orthographicSize = cameraDistance;
            }
        }
        playerPosition = new Vector3 (FindAnyObjectByType<Movement>().transform.position.x, FindAnyObjectByType<Movement>().transform.position.y, -10);
        transform.position = playerPosition;
        
        
    }
    
}
