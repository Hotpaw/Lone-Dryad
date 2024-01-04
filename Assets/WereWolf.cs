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

    public Transform[] stages;
    public float xThreshold = 0f;
    private Transform treeTransform;
    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
        // Find the Tree GameObject and get its transform
        GameObject tree = GameObject.FindGameObjectWithTag("Tree");
        if (tree != null)
        {
            treeTransform = tree.transform;
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
    private void FlipBasedOnTreePosition()
    {
        // Determine if the GameObject should face left or right based on the Tree's position
        bool shouldFaceLeft = transform.position.x < treeTransform.position.x;

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
}
