using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolf : MonoBehaviour
{
    public static WereWolf INSTANCE;

    public State IdleState;
    public State AttackState;
    public State JumpState;
    public State DieState;
    public State IntroState;

    public Animator animator;
    public Rigidbody2D rb;

    public Transform[] stages;
    public float xThreshold = 0f;

    private Transform closestTarget;
    public bool moveToAttack = false;

    void Awake()
    {
        INSTANCE = this;
        FindClosestWATarget();
    }

    void Update()
    {
        if (moveToAttack)
        {
            FindClosestWATarget();
            if (closestTarget != null)
            {
                // Add your logic here to transition to the AttackState
                // when the werewolf is closest to one of the "WA" targets
                // Example: TransitionToAttackState();
            }
        }
    }

    public void FindClosestWATarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("WA");
        float closestDistance = float.MaxValue;
        closestTarget = null;

        foreach (GameObject target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target.transform;
            }
        }

        if (closestTarget == null)
        {
            Debug.LogError("No GameObject with tag 'WA' found in the scene.");
        }
    }

    public void FlipBasedOnTreePosition()
    {
        GameObject tree = GameObject.FindGameObjectWithTag("Wtarget");
        if (tree != null)
        {
            Transform target = tree.transform;
            // Determine if the GameObject should face left or right based on the Tree's position
            bool shouldFaceLeft = transform.position.x < target.position.x;

            // Flip the sprite by adjusting the local scale
            if (shouldFaceLeft && transform.localScale.x > 0 || !shouldFaceLeft && transform.localScale.x < 0)
            {
                Flip();
            }
        }
    }

    public void FlipBasedOnTreePosition(bool jump, Transform targetToJump)
    {
        if (jump)
        {
            closestTarget = targetToJump;
        }
        // Determine if the GameObject should face left or right based on the Tree's position
        bool shouldFaceLeft = transform.position.x < closestTarget.position.x;

        // Flip the sprite by adjusting the local scale
        if (shouldFaceLeft && transform.localScale.x > 0 || !shouldFaceLeft && transform.localScale.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float GetAnimationClipDuration(string clipName)
    {
        if (animator.runtimeAnimatorController != null)
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                if (clip.name.Equals(clipName))
                {
                    return clip.length;
                }
            }
        }
        Debug.LogError($"Animation clip '{clipName}' not found");
        return 0f;
    }

    public void ResetAllAnimatorBools()
    {
        if (animator == null) return;

        // Iterate through all parameters
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            // Check if the parameter is a bool
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }

    public void ResetRigidbodyProperties()
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.gravityScale = 1; // Reset gravity scale to default
    }

    // Add any additional methods or logic here...
}
