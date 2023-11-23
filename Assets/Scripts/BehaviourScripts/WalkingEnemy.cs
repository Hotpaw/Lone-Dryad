using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    
    Vector3 end;
    Vector3 start;

    Rigidbody2D rb2D;

    float phase;
    float phaseDirection = 1;
    float speedWalk = 1.5f;

    // Start is called before the first frame update
    void Start()
    {


        start = transform.position + new Vector3 (-1, 0, 0);
        end = transform.position + new Vector3(1, 0, 0); 

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
       transform.position = Vector3.Lerp(start, end, phase); 
       phase += Time.deltaTime * speedWalk * phaseDirection;
      
        
        if (phase > 1 || phase <= 0)
        {
            phaseDirection *= -1;
        }
    }
}
