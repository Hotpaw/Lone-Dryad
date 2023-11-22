using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DetectingPlayer : MonoBehaviour
{
    public Transform target;

    float enemySpeed = 3f;

    Rigidbody2D rb2D;

    public float withinRange;



    // Start is called before the first frame update
    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Detection();
    }

    public void Detection()
    {

        //float detectRadius = Vector3.Distance(target.position, target.transform.position);
        float detectRadius = Vector2.Distance(transform.position, target.transform.position);

        if (detectRadius <= withinRange) 
        {

            Vector2 targetDirection = target.position - transform.position;

            targetDirection.Normalize();

            rb2D.velocity = targetDirection * enemySpeed;

            transform.right= target.position - transform.position;

            //Debug.Log("player in range");

        }
        else
        {

            rb2D.velocity= Vector2.zero;

            transform.rotation = Quaternion.identity;
        }

    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireSphere(transform.position, withinRange);


    }
}
