using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacleTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.up = FindAnyObjectByType<Movement>().transform.position - transform.position;
    }
}
