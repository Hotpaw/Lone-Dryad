using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DetectingPlayerAndCharge : MonoBehaviour
{
    public Transform target;

    float enemySpeed = 1.5f;

    Rigidbody2D rb2D;

    public float withinRange;

    float detectRadius;



    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Charge(1f)); //how much is the delay


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

    IEnumerator Charge(float chargedelay)
    {

        yield return new WaitForSeconds(chargedelay); //wait for specified delay 

        //action to perform after delay

        float detectRadius = Vector2.Distance(transform.position, target.transform.position);

        if (detectRadius <= withinRange)
        {

            enemySpeed+= 2.5f; //increase speed

        

            //Debug.Log("player in range" + enemySpeed);

        }
        else
        {

           rb2D.velocity = Vector2.zero; //no velocity when outside cirle

            transform.rotation = Quaternion.identity; //förhindrar rotation och spin

           
        }

        StartCoroutine(Charge(chargedelay)); //reset timer
    }
}
