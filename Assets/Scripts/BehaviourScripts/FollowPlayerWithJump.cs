using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FollowPlayerWithJump : MonoBehaviour
{

    Rigidbody2D rb2D;

    [SerializeField] public Vector3 direction = new Vector3(1, 1, 1);
     Transform target;
    float timerjump = 1f;
    public float jumpHeight;
    public float gravityForce = 5f;

    public bool isJumping = false;
    bool walking = true;
    public float jumpRange;
    bool jumponce = true;
    [SerializeField] public float walkSpeed = 2f;


    [SerializeField] public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<TreeScript>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            if (walking)
            {
                rb2D.gravityScale = 24;
                isJumping = false;
                transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);
            }
        }
        else
        {
            StartCoroutine(JumpWithGravity());
        }


        CheckDistanceToTarget();

    }


    public void CheckDistanceToTarget()
    {

        if (Vector2.Distance(target.position, transform.position) < jumpRange)
        {

            if(target != null)
            {

            Jump();
            }
            else
            {
                Debug.LogError("There was no target referenced in Jump script");
            }
        }
    }

    void Jump()
    {




        isJumping = true;
      

        if (jumponce)
        {
            rb2D.velocity = Vector2.zero;
            Vector2 jumpDirection = (target.position - transform.position);

            Vector2 jumpHeightOffset = Vector2.up * jumpHeight;
            rb2D.bodyType = RigidbodyType2D.Dynamic;

            rb2D.AddForce((jumpDirection + jumpHeightOffset) * jumpForce, ForceMode2D.Impulse);


        }



    }


    IEnumerator JumpWithGravity()
    {

        walking = false;

        Vector2 jumpDirection = (target.position - transform.position);
        rb2D.AddForce(Vector2.down * gravityForce, ForceMode2D.Force); //gravitation som ska dra ner
        rb2D.gravityScale = 1;

        yield return new WaitForSeconds(0.5f);
        jumponce = false;
        yield return new WaitForSeconds(timerjump);




    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, jumpRange);
    }


}
