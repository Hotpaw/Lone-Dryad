using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WerewolfJumpState : State
{
    public Transform target;
    public float timeToTarget = 1.0f;
    public Rigidbody2D rb;
    public Collider2D collider;
    bool jumped = false;
    Animator animator;
    public int jumpToAttack = 5;
    int jumps;
    public float arrivalDistance = 0.5f; // Adjust this threshold as needed

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
        if (Vector3.Distance(transform.position, target.position) <= arrivalDistance && jumps != jumpToAttack)
        {

            collider.enabled = true; // Re-enable collider
            rb.velocity = Vector2.zero; // Stop the werewolf
            rb.gravityScale = 10; // Reset gravity to normal
            jumped = false;
            return WereWolf.INSTANCE.IdleState;
        }
        else if (Vector3.Distance(transform.position, target.position) <= arrivalDistance && jumps == jumpToAttack)
        {
            WereWolf.INSTANCE.moveToAttack = true;
            jumps = 0;
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

        // Calculate distances to each target
        List<(Transform target, float distance)> targetDistances = new List<(Transform, float)>();
        foreach (Transform potentialTarget in WereWolf.INSTANCE.stages)
        {
            float distance = Vector3.Distance(transform.position, potentialTarget.position);
            targetDistances.Add((potentialTarget, distance));
        }

        // Sort targets by distance in descending order
        targetDistances.Sort((a, b) => b.distance.CompareTo(a.distance));

        // Take the two furthest targets
        var furthestTargets = targetDistances.Take(2).ToList();

        // Randomly select one of the two furthest targets
        if (furthestTargets.Count == 2)
        {
            target = furthestTargets[Random.Range(0, 2)].target;
        }
        else
        {
            // Fallback in case there's only one furthest target
            target = furthestTargets.FirstOrDefault().target;
        }
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
            WereWolf.INSTANCE.FlipBasedOnTreePosition(true, target);
            animator.SetTrigger("Jump");
            Debug.Log(WereWolf.INSTANCE.GetAnimationClipDuration("werewolf jump"));
            yield return new WaitForSeconds(WereWolf.INSTANCE.GetAnimationClipDuration("werewolf jump"));
            collider.enabled = false; // Disable collider during jump
            rb.gravityScale = 0; // Optional: Neutralize gravity during jump
            jumps++;
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
