using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfIntroState : State
{
    public float speed = 5f; // Speed of horizontal movement
    public float forceMultiplier = 1; // Adjust the force applied for movement

    public Rigidbody2D rb;
    private Transform target;
    bool introSet = false;
    public float closeEnoughDistance = 1.0f;
   public  bool hasTriggeredWithTarget = false; // New variable to track collision

    [Header("wereWolfGrowling")]
    public GameObject growling;
    void Start()
    {
        FindClosestTarget();
        WereWolf.INSTANCE.moveToAttack = false;
    }

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
        if (other.gameObject.CompareTag("Wtarget"))
        {
            hasTriggeredWithTarget = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wtarget"))
        {
            hasTriggeredWithTarget = false;
        }
    }
    public override State RunCurrentState()
    {
        growling.SetActive(true);
        Debug.Log(growling.gameObject.activeInHierarchy);
        WereWolf.INSTANCE.moveToAttack = false;
        if (!introSet)
        {
            introSet = true;
            WereWolf.INSTANCE.animator.SetTrigger("Walk");
            WereWolf.INSTANCE.FlipBasedOnTreePosition();
        }

        if (target != null)
        {
            MoveTowardsTargetAffectedByGravity();

            float distanceToTarget = Vector2.Distance(rb.position, target.position);

            if (distanceToTarget <= closeEnoughDistance || hasTriggeredWithTarget)
            {
                introSet = false;
                WereWolf.INSTANCE.ResetRigidbodyProperties();
                hasTriggeredWithTarget = false; // Reset the flag
                return WereWolf.INSTANCE.AttackState;
            }
        }

        return this;
    }
}
