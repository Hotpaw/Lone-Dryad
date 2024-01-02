using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform attackPoint;
    public float thrust;
    public LayerMask groundLayer;
    public LineRenderer trajectoryLine;
    public float attackSpeed = 1f; // Cooldown time in seconds

    private bool isCharging = false;
    private bool coolDown = false;
    private float gravityScale = 9.8f; // Gravity scale of the projectile
    private float theta = 45f; // Launch angle in degrees

    public Material lineMaterial;
    private float textureOffset = 0f;
    public float textureScrollSpeed = 1f;
    private bool hasThrown = false;
    private Animator playerAnimator;
  
    bool used = false;
    private void Start()
    {
        // Set the initial width of the LineRenderer
        trajectoryLine.startWidth = 1;
        trajectoryLine.endWidth = 1;
        if (trajectoryLine != null)
        {
            trajectoryLine.material = lineMaterial;
        }
        playerAnimator = FindObjectOfType<Movement>().gameObject.GetComponent<Animator>();

}

    void Update()
    {
        if (isCharging && !coolDown)
        {
            ShowTrajectory();
            ScrollTexture();
            UpdateTextureTiling();
        }

    }

    private void UpdateTextureTiling()
    {
        if (trajectoryLine != null)
        {
            float lineLength = CalculateLineLength();
            float tilingFactor = lineLength / 1; // desiredTileLength is the length you want each tile to cover

            // Adjust the tiling of the texture
            Vector2 textureScale = new Vector2(tilingFactor, 1);
            trajectoryLine.material.mainTextureScale = textureScale;
        }
    }

    private float CalculateLineLength()
    {
        float length = 0f;

        for (int i = 0; i < trajectoryLine.positionCount - 1; i++)
        {
            length += Vector3.Distance(trajectoryLine.GetPosition(i), trajectoryLine.GetPosition(i + 1));
        }

        return length;
    }

    private void ScrollTexture()
    {
        if (trajectoryLine.material != null)
        {
            textureOffset -= Time.deltaTime * textureScrollSpeed;

            // Loop the offset
            textureOffset = textureOffset % 1.0f;

            trajectoryLine.material.mainTextureOffset = new Vector2(textureOffset, 0);
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");

        // Check if the player has the power to attack
        bool canAttack = GameValueManager.INSTANCE.thePowerToThrowNuts;

        if (context.performed && canAttack)
        {

            if (!coolDown && !hasThrown && used == false)
            {

                isCharging = !isCharging; // Toggle charging state
                trajectoryLine.enabled = isCharging; // Toggle LineRenderer visibility

                if (!isCharging && used == false) // If charging is turned off
                {

                    Attacking();
                    hasThrown = true;
                }
            }
        }
    }



    public void Attacking()
    {
        Debug.Log("ATTACK");
        if (!used)
        {
            
            used = true;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        
        coolDown = true;
       
        //  yield return new WaitForSeconds(0.1f);
        playerAnimator.SetTrigger("Thrown");
        yield return new WaitForSeconds(0.3f);
        FireProjectile();
        yield return new WaitForSeconds(attackSpeed);
        coolDown = false;
        used = false;
        hasThrown = false; // Reset the hasThrown flag after cooldown
       
    }

    private void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; // Set gravity scale

        Vector2 forceDirection = CalculateForceDirection();
        rb.AddForce(forceDirection * thrust, ForceMode2D.Impulse);
    }

    private Vector2 CalculateForceDirection()
    {
        bool right = FindAnyObjectByType<Movement>().right;
        float angleInRadians = (right ? theta : 180 - theta) * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
    }

    private void ShowTrajectory()
    {
        int resolution = 200;
        trajectoryLine.positionCount = resolution;

        Vector2 startPosition = attackPoint.position;
        Vector2 velocity = CalculateForceDirection() * thrust;
        Vector2 gravity = Physics2D.gravity * gravityScale;

        for (int i = 0; i < resolution; i++)
        {
            float t = i / (float)resolution;
            Vector2 position = startPosition + velocity * t + 0.5f * gravity * t * t;
            trajectoryLine.SetPosition(i, position);

            if (Physics2D.OverlapPoint(position, groundLayer))
            {
                trajectoryLine.positionCount = i + 1;
                break;
            }
        }
    }

}