using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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

    public Transform[] stages;
    public float xThreshold = 0f;
    private Transform target;
    public bool moveToAttack = false;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        INSTANCE = this;
        // Find the Tree GameObject and get its transform
        GameObject currentTarget = GameObject.FindGameObjectWithTag("Wtarget");
        if (currentTarget != null)
        {
            target = currentTarget.transform;
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Tree' found in the scene.");
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipBasedOnTreePosition()
    {
        GameObject tree = GameObject.FindGameObjectWithTag("Wtarget");
        target = tree.transform;
        // Determine if the GameObject should face left or right based on the Tree's position
        bool shouldFaceLeft = transform.position.x < target.position.x;

        // Flip the sprite by adjusting the local scale
        if (shouldFaceLeft && transform.localScale.x > 0 || !shouldFaceLeft && transform.localScale.x < 0)
        {
            Flip();
        }
    }
    public void FlipBasedOnTreePosition(bool jump, Transform targetToJump)
    {
        if(jump)
        {
            target = targetToJump;
        }
        // Determine if the GameObject should face left or right based on the Tree's position
        bool shouldFaceLeft = transform.position.x < target.position.x;

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
}
