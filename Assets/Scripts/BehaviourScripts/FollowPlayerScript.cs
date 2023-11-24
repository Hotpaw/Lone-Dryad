using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
 
   public Transform target;
   Rigidbody2D rb2D;
   public float enemySpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("EnemyFollow", 0.5f);

        

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector2 targetDirection = target.position - transform.position;

            targetDirection.Normalize();

            rb2D.velocity = targetDirection * enemySpeed;

            transform.right = target.position - transform.position;

            transform.rotation = Quaternion.identity;

        }

    }

   
    
}

