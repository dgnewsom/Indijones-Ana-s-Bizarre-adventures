using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Extends Interactable Script
/// Intereactive Object to activate an animator's animation
/// good for doors or bridges
/// </summary>
public class AnimatorInteractable : InteractableScript
{
    [Header("Animator")]
    public Animator animator;
    public string boolName = "Activate";

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }


    private void Start()
    {
        playAnimation();
    }

    public override void activate()
    {
        base.activate();
        playAnimation();
    }

    public override void deactivate()
    {
        base.deactivate();
        playAnimation();
    }

    /// <summary>
    /// set the boolean of the parameter in the animator
    /// </summary>
    void playAnimation()
    {
        animator.SetBool(boolName, interactableActive);
    }
    /// <summary>
    /// set the boolean of the parameter in the animator
    /// </summary>
    /// <param name="t">bool of the parameter in the animator</param>
    void playAnimation(bool t)
    {
        animator.SetBool(boolName, t);
    }
}
