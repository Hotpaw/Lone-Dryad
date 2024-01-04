using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfIntroState : State
{


    public Rigidbody2D rb;
    private Transform target;
    bool introSet = false;
    public float closeEnoughDistance = 1.0f;

    public bool attack = false;
    public bool collidedWithTarget = false; // New variable to track collision
    public float speed = 5f; // Speed of horizontal movement
      public float forceMultiplier = 1; // Adjust the force applied for movement

    
   

    private void FindClosestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Wtarget");
        float closestDistance = float.MaxValue;
        target = null;

        foreach (GameObject potentialTarget in targets)
        {
            float distance = Vector2.Distance(rb.position, potentialTarget.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = potentialTarget.transform;
            }
        }

        if (target == null)
        {
            Debug.LogError("No GameObject with tag 'Wtarget' found in the scene.");
        }
    }

    private void MoveTowardsTargetAffectedByGravity()
    {
        if (target != null)
        {
            float directionX = target.position.x - rb.position.x;
            directionX = Mathf.Sign(directionX);

            Vector2 force = new Vector2(directionX * speed * forceMultiplier, rb.velocity.y);
            rb.velocity = force;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wtarget"))
        {
            collidedWithTarget = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wtarget"))
        {
            collidedWithTarget = false;
        }
    }

  
    void Start()
    {
        FindClosestTarget();
        WereWolf.INSTANCE.moveToAttack = false;

        if (!introSet)
        {

            introSet = true;
            WereWolf.INSTANCE.animator.SetTrigger("Walk");
            WereWolf.INSTANCE.FlipBasedOnTreePosition();
        }
        // Find the Tree GameObject and get its transform
        GameObject tree = GameObject.FindGameObjectWithTag("Wtarget");
        if (tree != null)
        {
            target = tree.transform;
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Tree' found in the scene.");
        }
    }

    void FixedUpdate()
    {

    }

    private void MoveTowardsTarget()
    {
        Vector2 targetPosition = new Vector2(target.position.x, rb.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);

        // Apply the movement
        rb.MovePosition(newPosition);
    }

    public override State RunCurrentState()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
        if (target != null)
        {
            float distanceToTarget = Vector2.Distance(rb.position, target.position);

            if (distanceToTarget <= closeEnoughDistance)
            {

                WereWolf.INSTANCE.moveToAttack = false;
                introSet = false;

                attack = false;

                collidedWithTarget = false; // Reset the collision flag

                return WereWolf.INSTANCE.AttackState;
            }
            else { return this; }
        }
        else
        {
              return this;
        }

    }
}
