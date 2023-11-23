using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{

    //ground check

    //collision check

    //detecting enemy

    //jum check 

    Rigidbody2D rb2D;

    float move;
    public float jump;
    public float speed;

    bool onGround;


    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody2D rb2d2 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void OnCollisionEnter2D(Collision2D other) //ground check. true när spelaren touchar marken. 
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            onGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other) //false när spelarne inte är på marken
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            onGround = false;
        }
    }
}
