using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfIntroState : State
{

    public float speed = 5f; // Speed of movement

    public Rigidbody2D rb;
    private Transform target;
    bool introSet = false;
    public float closeEnoughDistance = 1.0f;
    void Start()
    {

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

