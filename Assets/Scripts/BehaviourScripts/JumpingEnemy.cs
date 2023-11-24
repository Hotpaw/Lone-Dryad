using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{

    //ground check

    //collision check

    //detecting enemy

    //jum check 

   

    Rigidbody2D enemy2D;

   [Header("For Petrolling")]
   [SerializeField] float moveSpeed;
   [SerializeField] Transform onGroundCheck; //check if enemy is on ground
   [SerializeField] Transform wallCheck; //if enemy is on wall
   [SerializeField] public float radius; //radius on detection circle
   [SerializeField] public LayerMask groundLayer;
   float spriteDirection = 1; //which direction enemy is moving. 1 Is for "right" side of the x axis. -1 woudl be left. You can choose which sixe you want it to start. 
   public bool facingRight = true; //which way enemy is facing
   public bool onGround; //gróund check
   public bool againstWall; //wall check


    [Header("JumpAttack")]
    [SerializeField] float enemyJumpHeight;
    [SerializeField] Transform target;
    [SerializeField] Transform checkingGround;
    [SerializeField] Vector2 boxSize; //istället för float radius av cirkel, är det overlapbox, så då blir dte vector 2.
    [SerializeField] bool isOnGround;




    // Start is called before the first frame update
    void Start()
    {
        
        enemy2D = GetComponent<Rigidbody2D>();

    }



    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(onGroundCheck.position, radius, groundLayer);   //kollar om enemy är på ground. Overlap cirle kollar om det är några colliders som överlappar med radius
        //allså en cirkels storlek. Den retuernerar null om inte, annars returnerar collider. groundcheck position är mitten av cirkeln. raidus storlek, och gorundlayer är vilket layer den ska kolla som överlappar. 
        againstWall = Physics2D.OverlapCircle(wallCheck.position, radius, groundLayer);

        isOnGround = Physics2D.OverlapBox(checkingGround.position, boxSize, 0, groundLayer); //samma som ovan, fast vecto1 och 0 är "angle".

        EnemyPetrolling();
    }


    public void EnemyPetrolling()
    {
        if (!onGround || againstWall) // om nu enemy inte checkar markeb men checkar emot en vägg så...
        {
        
           if (facingRight) //är den riktaf mot höger
           {

                EnemyFlipSide(); //är den åt höger ska den flippa till vänster
           }
           else if (!facingRight) 
           {

                EnemyFlipSide(); //är den åt vänster ska den flippa till höger

           }


        }
        enemy2D.velocity = new Vector2(moveSpeed * spriteDirection, enemy2D.velocity.y);


    }


    void JumpAttack()
    {

        float distanceFromPlayer = target.position.x - transform.position.x;

        if (isOnGround) //om nu spelaren är på marken...
        {
            enemy2D.AddForce(new Vector2(distanceFromPlayer, enemyJumpHeight), ForceMode2D.Impulse); //så ska spelaren hoppa.ForceMode.2d är för impuler så som hopp, snabba ryck.You Apply impulse to jump towards the player 
        }

    }



    void EnemyFlipSide() //make the enemy flipside when detetcting a wall
    {
        spriteDirection *= -1; //direction turn left
        facingRight =!facingRight; //om det står false så checkar den inte om den facar höger eller inte. 
        transform.Rotate (0, 180, 0); //byter håll på spriten. 0 för x, 180 för y axeln, och 0 för z. 

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(onGroundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
        
    }




    //public float jumpForce;
    //float playerWithinRange;


    // Update is called once per frame
    void Update()
    {

        //if (Vector2.Distance(transform.position, target.position) <= radius)
        //{

        //  //jump towards enemy function
        //}

    }


    //public void OnCollisionEnter2D(Collision2D other) //ground check. true när spelaren touchar marken. 
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {

    //        onGround = true;
    //    }
    //}

    //public void OnCollisionExit2D(Collision2D other) //false när spelarne inte är på marken
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {

    //        onGround = false;
    //    }
    //}


    //public void JumpTowardsPlayer()
    //{

    //    Vector2 directionEnemy = target.position - transform.position;

    //    enemy2D.AddForce(directionEnemy.normalized * jumpForce, ForceMode2D.Impulse);

    //}

}
