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

    private void Start()
    {
      
            // Set the initial width of the LineRenderer
            trajectoryLine.startWidth *= 0.5f; // 50% thinner
            trajectoryLine.endWidth *= 0.5f;   // 50% thinner

            // Set the color to green with 30% opacity
            Color greenColor = new Color(0, 1, 0, 0.3f); // Green with 30% opacity
            trajectoryLine.material.color = greenColor;
        
    }
    void Update()
    {
        if (isCharging && !coolDown)
        {
            ShowTrajectory();
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        // Check if the player has the power to attack
        bool canAttack = GameValueManager.INSTANCE.thePowerToThrowNuts;

        if (context.performed && !coolDown && canAttack)
        {
            isCharging = !isCharging; // Toggle charging state
            trajectoryLine.enabled = isCharging; // Toggle LineRenderer visibility

            if (!isCharging) // If charging is turned off, fire the projectile
            {
                FireProjectile();
                StartCoroutine(AttackCooldown());
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        coolDown = true;
        yield return new WaitForSeconds(attackSpeed);
        coolDown = false;
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

    // Implement FindAnyObjectByType<Movement>() method if it's not already defined
}
