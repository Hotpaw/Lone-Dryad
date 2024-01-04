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
    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
      
    }

    // Update is called once per frame
    void Update()
    {
        
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
