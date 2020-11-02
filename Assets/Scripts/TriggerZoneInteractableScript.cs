using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extend Interactable Script
/// controls connected Interactable scipts when the player enter the trigger zone
/// </summary>
public class TriggerZoneInteractableScript : InteractableScript
{
    
    public enum TriggerType
    {
        TOGGLE,
        ACTIVE,
        DEACTIVE,
        NONE
    }
    
    [Header("Trigger")]
    public PlayerInteractionScript playerInteractionScript;
    public List<InteractableScript> interactTargets;
    public Animator animator;
    public MeshRenderer meshRenderer;
    [Header("Trigger Behaviour")]
    public TriggerType onEnter = TriggerType.ACTIVE;
    public TriggerType onExit = TriggerType.DEACTIVE;
    public List<string> tagList;
    [Header("Timer")]
    public float timer = 0f; //will not deactivate if timer is 0;
    bool timerStart = false;
    float timer_Now = 0;
    Coroutine currentCoroutine;



    private void OnTriggerEnter(Collider other)
    {
        if (tagList.Contains(other.tag))
        {
            onBehaviour(onEnter);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (tagList.Contains(other.tag))
        {
            onBehaviour(onExit);
        }
    }






    void onBehaviour(TriggerType t)
    {

        switch (t)
        {
            case (TriggerType.ACTIVE):
                setActivationForList(interactTargets, true);
                base.activate();
                
                break;
            case (TriggerType.DEACTIVE):
                setActivationForList(interactTargets, false);
                base.deactivate();
                break;
            case (TriggerType.TOGGLE):
                toggleActivationForList(interactTargets);
                base.toggleActivate();
                break;
            case (TriggerType.NONE):
                break;
        }
        updateZoneAnimation(interactableActive);
    }



    void updateZoneAnimation(bool t)
    {
        if (t)
        {
            animator.SetBool("Active", true);
        }
        else
        {
            animator.SetBool("Active", false);

        }
    }
}
