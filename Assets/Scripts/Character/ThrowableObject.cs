using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 forceDirn;
    float theta;
    public float thrust;

    public void Start()
    {
        bool right = FindAnyObjectByType<Movement>().right;
        rb = GetComponent<Rigidbody2D>();

       
        theta = 45f * 3.14f / 180f;
        if (!right)
        {
            Debug.Log("LEFT");
            forceDirn.x = Mathf.Cos(theta) * -1;
            forceDirn.y = Mathf.Sin(theta);
        }
        else
        {
            Debug.Log("RIGHT");
            forceDirn.x = Mathf.Cos(theta);
            forceDirn.y = Mathf.Sin(theta);
        }
        

        // You can change this or set it in the editor itself
        float gravity = 9.8f;
        rb.gravityScale = gravity;

      
        rb.AddForce(forceDirn * thrust, ForceMode2D.Impulse);
    }


}


