
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    [Header("Move Variables")]
    public float maxSpeed;
    public float acceleration = 20;
    public float deacceleration = 4;

    [Header("Jump Variables")]
    public float jumpPower;
    public float fallMultiplier;
    public float groundCheckLength;
    public float coyoteTime;
    public float jumpPressLeniancy;
    public float upperVerticalVelocityClamp;
    public float lowerVerticalVelocityClamp;
    public Vector2 groundCheckBoxSize;
    public LayerMask groundLayer;
    public bool isGrounded;

    public bool isCrawling;

    [Header("Dash Variables")]
    public float dashStrength;
    public float dashCooldown;
    private float dashTimer;

    [Header("Dead")]
    public bool dead;

    private float xInput;
    private float velocityX;
    private float timeSinceGrounded = 1;
    private float timeSinceJumpPressed = 1;
    private float gravityscale;
    private bool doubleJump;
    private bool isDashing;
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    private Animator animator;

    private Vector2 vecGravity;
    bool jumpCallBeingPressed;

    public bool right;
    public float savedMaxSpeed;
    public bool pickedUp = false;
    private bool isAlwaysRunning = false;
    //KC
    bool kc;
    Vector2 position;
    public SpriteRenderer InteractableObject;
    public GameObject dropShadow;

    [Header("Regular Footsteps")]
    public GameObject[] footStep;
    public GameObject steps;
    [Header("JumpSound")]
    public GameObject jump;
    private void Start()
    {
        steps = footStep[0];
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        gravityscale = rb.gravityScale;


    }

    void Update()
    {
        UpdateShadow();
        var controllers = Input.GetJoystickNames();
        dashTimer += Time.deltaTime;
        timeSinceGrounded += Time.deltaTime;
        timeSinceJumpPressed += Time.deltaTime;
        ToggleRun();

        bool isSprinting = false;
        if (Gamepad.current != null)
        {
            isSprinting = Gamepad.current.leftShoulder.isPressed;
        }
        if (Keyboard.current != null)
        {
            isSprinting = isSprinting || Keyboard.current.shiftKey.isPressed;
           
        }

        // Adjust maxSpeed based on whether the player is sprinting
        maxSpeed = isSprinting ? 12f : 5f;
        if (rb.velocity.x > 0.1 || rb.velocity.x < -0.1 && isGrounded)
        {
            
            //Debug.Log(steps.name);
            steps.SetActive(true);
            //Debug.Log(steps.gameObject.activeInHierarchy);
        }
        else
            steps.SetActive(false);
      
        if (maxSpeed > 5) 
        {
          
           steps.SetActive(false);
            
        }

        if (!isDashing && !dead)
        {
            if (!GameValueManager.INSTANCE.treeIsALive || GameValueManager.INSTANCE.gameWon)
            {
                rb.velocity = Vector2.zero;
            }
            else
                MovementHorizontal(); 

            GroundCheck();
            Flip();

            if (rb.velocity.y < 0 || !jumpCallBeingPressed)
                rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime; 


            if (Mathf.Abs(rb.velocity.y) < 0.5f)
                rb.gravityScale = gravityscale / 4;
            else
                rb.gravityScale = gravityscale;

            if (timeSinceJumpPressed < jumpPressLeniancy && (timeSinceGrounded < coyoteTime || doubleJump))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);

                if (timeSinceGrounded > coyoteTime)
                    doubleJump = false;
                animator.SetBool("Jump", true);


                
            }
            else
            {
                animator.SetBool("Jump", false);
               
            }




            RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.up, groundCheckLength + 0.1f, groundLayer);

            //if (ray && ray.collider.gameObject.CompareTag("Ice"))
            //    deacceleration = 0;
            //else
            //    deacceleration = 15;


        }
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -lowerVerticalVelocityClamp, upperVerticalVelocityClamp));
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("VerticalSpeed", rb.velocity.y);
        animator.SetBool("Dead", dead);


        //  animator.SetBool("Crawl", isCrawling);
        //KC
        kc = GameValueManager.INSTANCE.KC;
        animator.SetBool("KC", kc);
        if (kc)
        {
            maxSpeed = 25;
            position.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
            position.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
            transform.position = position;
        }

    }

    public void FootSteps()
    {
        steps.SetActive(true);
    }

    public void StopFootSteps()
    {
        steps.SetActive(false);
    }


    private void ToggleRun()
    {
      
        if ((Gamepad.current != null && Gamepad.current.leftShoulder.wasPressedThisFrame) ||
       Keyboard.current.rKey.wasPressedThisFrame)
        {
            ToggleRunWalk();
            
        }


        if (isAlwaysRunning)
        {
            maxSpeed = 12f; // Running speed
            
           
        }
        else
        {
            maxSpeed = 5f; // Walking speed
            
         

        }
    }

    public void ToggleRunWalk()
    {
        isAlwaysRunning = !isAlwaysRunning;
        savedMaxSpeed = maxSpeed; // Save the current maxSpeed
       
    }
    public void PickupAnimation()
    {
        animator.SetTrigger("PickingUP");
    }

    public void IncreaseSpeed()
    {
        isCrawling = false;
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            animator.SetBool("Crawl", false);
        }
        else
        {
            animator.SetBool("Crawl", false);
        }
        maxSpeed = savedMaxSpeed;
    }
    public void DecreaseSpeed()
    {
        maxSpeed *= 0.5f;
        isCrawling = true;
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            animator.SetBool("Crawl", true);
        }
        else
        {
            animator.SetBool("Crawl", true);
        }


    }

    public void Flip()
    {
        if (xInput < -0.1f)
        {
            right = false;
            playerSprite.flipX = false;
        }
        else if (xInput > 0.1f)
        {
            right = true;
            playerSprite.flipX = true;
        }

    }

    public void Dash(InputAction.CallbackContext context)
    {
        //if (context.action.IsPressed() && dashTimer > dashCooldown && !dead)
        //{
        //    int i;


        //    if (playerSprite.flipX)
        //        i = -1;
        //    else
        //        i = 1;

        //    isDashing = true;
        //    rb.velocity = new Vector2(i * dashStrength, 0);
        //    rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        //    dashTimer = 0;
        //    Invoke("DashDone", 0.2f);
        //    animator.SetBool("Dash", true);
        //}
    }

    public void DashDone()
    {
        isDashing = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.SetBool("Dash", false);
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!isCrawling)
        {
            jumpCallBeingPressed = context.action.IsPressed();

               

            if (context.action.WasPressedThisFrame())
            {
                timeSinceJumpPressed = 0;
            }
           
            if (!isGrounded)
                jump.SetActive(true);
            else if (isGrounded)
                jump.SetActive(false); 
            
        }

    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.BoxCast(transform.position, groundCheckBoxSize, 0, -transform.up, groundCheckLength, groundLayer);
        if (isGrounded)
        {
            doubleJump = false;
            timeSinceGrounded = 0;
        }

        
        animator.SetBool("Grounded", isGrounded);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        xInput = context.ReadValue<float>();
    }

    private void MovementHorizontal()
    {
        velocityX += xInput * acceleration * Time.deltaTime;

        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        if (xInput == 0 || (xInput < 0 == velocityX > 0))
        {
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    void UpdateShadow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, groundLayer);
        if (hit.collider != null)
        {
            // Calculate the distance to the ground
            float distanceToGround = Vector2.Distance(hit.point, transform.position);
            // Adjust the scale of the shadow based on the distance
            float shadowScale = Mathf.Clamp(1 - distanceToGround / 10, 0.1f, 1); // Adjust these values as needed

            // Position the shadow directly above the ground layer
            dropShadow.transform.position = new Vector2(transform.position.x, hit.point.y);
            // Scale the shadow
            dropShadow.transform.localScale = new Vector3(shadowScale, shadowScale, 1);
        }
    }
}
