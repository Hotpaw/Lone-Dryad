using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FollowPlayerWithJump : MonoBehaviour
{

    Rigidbody2D rb2D; 

    [SerializeField] public Vector3 direction = new Vector3 (1, 1, 1);
    public Transform target;
    float timerjump = 1f;
    public float jumpHeight;
    public float gravityForce = 5f;

    public bool isJumping = false;

   
    [SerializeField] public float walkSpeed = 2f;
   

    [SerializeField] public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            isJumping = false;
            transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);
        }
        else
        {
            //CheckDistanceToTarget();
        }

        //if (transform.position.x > target.position.x)
        //{
        //    rb2D.velocity = Vector2.zero;
        //}
       
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
       
        if (other.gameObject.tag == "Jump")
        {
            Debug.Log("Jumping");

            Jump();

        }
        else if ((other.gameObject.tag == "Tree"))
        {
            rb2D.velocity = Vector2.zero;

        }
        else
        {
            StartCoroutine(JumpWithGravity());
        }

        

    }

    void Jump()
    {


        Debug.Log("Jumping function");
        isJumping = true;
        rb2D.velocity = Vector2.zero;
        Vector2 jumpDirection = (target.position - transform.position);

        Vector2 jumpHeightOffset = Vector2.up * jumpHeight;
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        rb2D.AddForce((jumpDirection + jumpHeightOffset) * jumpForce, ForceMode2D.Impulse);


    }

    //void CheckDistanceToTarget()
    //{
    //   float distance = Vector2.Distance(transform.position, target.position);
       
    //}
    IEnumerator JumpWithGravity()
    {
       
        
        
            Vector2 jumpDirection = (target.position - transform.position);
            rb2D.AddForce(Vector2.down * gravityForce, ForceMode2D.Force); //gravitation som ska dra ner
        
   

        yield return new WaitForSeconds(timerjump);

        
       
       
    }


}
