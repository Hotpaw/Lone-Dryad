using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfJumpState : State
{
    public Transform target;
    public float timeToTarget = 1.0f;
    public Rigidbody2D rb;
    public Collider2D collider;
    bool jumped = false;
    Animator animator;
    public float arrivalDistance = 0.5f; // Adjust this threshold as needed
    public int jumpsUntilattack = 5;
    int jumps = 0;
    public override State RunCurrentState()
    {
       
        animator = WereWolf.INSTANCE.animator;
        if (!jumped)
        {
            SelectNewTarget();

            Jump();
            jumped = true;
        }

        // Check if the werewolf is close to the target position
        if (Vector3.Distance(transform.position, target.position) <= arrivalDistance && jumps != jumpsUntilattack)
        {
           
            collider.enabled = true; // Re-enable collider
            rb.velocity = Vector2.zero; // Stop the werewolf
            rb.gravityScale = 10; // Reset gravity to normal
            jumped = false;
            return WereWolf.INSTANCE.IdleState;
        }
        else if ((Vector3.Distance(transform.position, target.position) <= arrivalDistance && jumps == jumpsUntilattack))
        {
            jumps = 0;
            WereWolf.INSTANCE.moveToAttack = true;
            collider.enabled = true; // Re-enable collider
            rb.velocity = Vector2.zero; // Stop the werewolf
            rb.gravityScale = 10; // Reset gravity to normal
            jumped = false;
            return WereWolf.INSTANCE.IdleState;
        }
        return this;
    }
    private void SelectNewTarget()
    {
        if (WereWolf.INSTANCE.stages.Length <= 1)
        {
            Debug.LogError("Not enough stages to select a new target.");
            return;
        }

        Transform newTarget;
        do
        {
            newTarget = WereWolf.INSTANCE.stages[Random.Range(0, WereWolf.INSTANCE.stages.Length)];
        }
        while (newTarget == target);

        target = newTarget;
    }
    void Jump()
    {
        WereWolf.INSTANCE.ResetAllAnimatorBools();
        StartCoroutine(JumpLogic());
    }
    IEnumerator JumpLogic()
    {

        if (target != null)
        {
            rb.velocity = Vector2.zero;
           
            jumps++;
            animator.SetTrigger("Jump");
            WereWolf.INSTANCE.FlipBasedOnTreePosition(true, target);
            Debug.Log(WereWolf.INSTANCE.GetAnimationClipDuration("werewolf jump"));
            yield return new WaitForSeconds(WereWolf.INSTANCE.GetAnimationClipDuration("werewolf jump"));
            collider.enabled = false; // Disable collider during jump
            rb.gravityScale = 0; // Optional: Neutralize gravity during jump

            Vector3 toTarget = target.position - transform.position;
            Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);

            float distanceXZ = toTargetXZ.magnitude;
            float velocityXZ = distanceXZ / timeToTarget;
            float velocityY = (toTarget.y - 0.5f * Physics2D.gravity.y * Mathf.Pow(timeToTarget, 2)) / timeToTarget;

            Vector3 initialVelocity = toTargetXZ.normalized * velocityXZ + Vector3.up * velocityY;
            rb.velocity = initialVelocity;
        }
        else
        {
            yield return new WaitForSeconds(0);
            Debug.LogError("Target is not assigned");
        }
    }
}
