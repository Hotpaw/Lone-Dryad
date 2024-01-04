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

    public override State RunCurrentState()
    {
        animator = WereWolf.INSTANCE.animator;
        if (!jumped)
        {
            Jump();
            jumped = true;
        }

        // Check if the werewolf is close to the target position
        if (Vector3.Distance(transform.position, target.position) <= arrivalDistance)
        {

            collider.enabled = true; // Re-enable collider
            rb.velocity = Vector2.zero; // Stop the werewolf
            rb.gravityScale = 10; // Reset gravity to normal
            return WereWolf.INSTANCE.IdleState;
        }
        return this;
    }

    void Jump()
    {
        WereWolf.INSTANCE.ResetAllAnimatorBools();
        StartCoroutine(JumpLogic());
    }
    IEnumerator JumpLogic()
    {
        target = WereWolf.INSTANCE.stages[Random.Range(0, WereWolf.INSTANCE.stages.Length)];
        if (target != null)
        {
            animator.SetTrigger("Jump");
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
