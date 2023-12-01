using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float cameraDistance;
    Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3 (FindAnyObjectByType<Movement>().transform.position.x, FindAnyObjectByType<Movement>().transform.position.y, cameraDistance);
        transform.position = playerPosition;
        
        
    }
    
}
