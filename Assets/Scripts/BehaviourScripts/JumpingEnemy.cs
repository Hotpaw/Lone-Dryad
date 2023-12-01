using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

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
   public bool onGround; //gr�und check
   public bool againstWall; //wall check


    [Header("JumpAttack")]
    [SerializeField] public float enemyJumpHeight;
    [SerializeField] Transform target;
    [SerializeField] Transform checkingGround;
    [SerializeField] Vector2 boxSize; //ist�llet f�r float radius av cirkel, �r det overlapbox, s� d� blir dte vector 2.
    [SerializeField] bool isOnGround;
    [SerializeField] public float jumpAngle;

    [Header("Seeing Player")]
    [SerializeField] Vector2 lineOfSight;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool canSeePlayer;
    




    // Start is called before the first frame update
    void Start()
    {
        
        enemy2D = GetComponent<Rigidbody2D>();

    }



    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(onGroundCheck.position, radius, groundLayer);   //kollar om enemy �r p� ground. Overlap cirle kollar om det �r n�gra colliders som �verlappar med radius
        //alls� en cirkels storlek. Den retuernerar null om inte, annars returnerar collider. groundcheck position �r mitten av cirkeln. raidus storlek, och gorundlayer �r vilket layer den ska kolla som �verlappar. 
        againstWall = Physics2D.OverlapCircle(wallCheck.position, radius, groundLayer);

        isOnGround = Physics2D.OverlapBox(checkingGround.position, boxSize, jumpAngle, groundLayer); //samma som ovan, fast vecto1 och 0 �r "angle".

        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSight, jumpAngle, playerLayer);


        //if (!canSeePlayer && isOnGround) 
        //{
        //    FlipToPlayer();
        //    EnemyPetrolling();


        //}
        //else if (canSeePlayer) 
        //{

        //    JumpAttack();


        //}

        EnemyPetrolling();


    }


    public void EnemyPetrolling()
    {
        if (!onGround || againstWall) // om nu enemy inte checkar marken men checkar emot en v�gg s�...
        {
        
           if (facingRight) //�r den riktaf mot h�ger
           {

                EnemyFlipSide(); //�r den �t h�ger ska den flippa till v�nster
           }
           else if (!facingRight) 
           {

                EnemyFlipSide(); //�r den �t v�nster ska den flippa till h�ger

           }


        }
        enemy2D.velocity = new Vector2(moveSpeed * spriteDirection, enemy2D.velocity.y);


    }

    void FlipToPlayer()
    {
        float playerPosition = target.position.x - transform.position.x;

        if (playerPosition < 0 && facingRight)
        {

            EnemyFlipSide();

        }
        else if (playerPosition > 0 && !facingRight)
        {
            EnemyFlipSide();
        }

    }


    void JumpAttack()
    {

        float distanceFromPlayer = target.position.x - transform.position.x; //enemyn tittar hur l�ngt ifr�n den �r f�rn spelaren f�r att kunan g�ra sitt hopp.

       /* if (isOnGround)*/ //om nu spelaren �r p� marken, och efter dne caluclerat hur l�ngt den �r fr�n playern...
        //{
            enemy2D.AddForce(new Vector2(distanceFromPlayer, enemyJumpHeight), ForceMode2D.Impulse); //s� ska spelaren hoppa.ForceMode.2d �r f�r impuler s� som hopp, snabba ryck.You Apply impulse to jump towards the player 
        //}

    }



    void EnemyFlipSide() //make the enemy flipside when detetcting a wall
    {
        spriteDirection *= -1; //direction turn left
        facingRight =!facingRight; //om det st�r false s� checkar den inte om den facar h�ger eller inte. 
        transform.Rotate (0, 180, 0); //byter h�ll p� spriten. 0 f�r x, 180 f�r y axeln, och 0 f�r z. 

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(onGroundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(checkingGround.position, boxSize);
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube (transform.position, lineOfSight); //drawWire(..) g�r cuben, spheren etc ih�lig och inte t�cker spelaren, om mna nu inte vill det. 

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


    //public void OnCollisionEnter2D(Collision2D other) //ground check. true n�r spelaren touchar marken. 
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {

    //        onGround = true;
    //    }
    //}

    //public void OnCollisionExit2D(Collision2D other) //false n�r spelarne inte �r p� marken
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
