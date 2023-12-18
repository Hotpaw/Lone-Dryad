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

    private void Awake()
    {

        cameraDistance = 11;
            cameras = FindObjectsOfType<Camera>();
        
        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = cameraDistance;
        }
    }
    // Update is called once per frame
    void Update()
    {
      
        playerPosition = new Vector3 (FindAnyObjectByType<Movement>().transform.position.x, FindAnyObjectByType<Movement>().transform.position.y, -10);
        transform.position = playerPosition;
        
        
    }
    
}
