using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extends Interactable Script
/// for handling button behaviour 
/// </summary>
public class ButtonInteractableScript : InteractableScript
{
    public enum ButtonType
    {
        TOGGLE,
        ACTIVE,
        DEACTIVE
    }
    [Header("Boutton")]
    public ButtonType buttonType;
    public PlayerInteractionScript playerInteractionScript;
    public List<InteractableScript> interactTargets;
    public Animator animator;
    public MeshRenderer meshRenderer;
    [Header("Timer")]
    public float timer = 0f; //will not deactivate if timer is 0;
    [SerializeField] float timer_Now = 0;
    Coroutine currentCoroutine;

    private void Start()
    {
        updateButtonAnimation(interactableActive);

    }
    private void FixedUpdate()
    {
        if (timer >0 && timer_Now < timer + 0.6f)
        {
            timer_Now += Time.deltaTime;
            meshRenderer.material.SetFloat("_StepValue", timer_Now / timer);
        }
    }

    //Tigger Zone handling
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && getPlayerInteraction(other.gameObject))
        {
            playerInteractionScript.setFocus(this);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && getPlayerInteraction(other.gameObject))
        {
            playerInteractionScript.setFocus(null);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && getPlayerInteraction(other.gameObject))
        {
            if (playerInteractionScript.currentFocus == null)
            {
                playerInteractionScript.setFocus(this);
            }
        }
    }

    //Button Behavoiur
    /// <summary>
    /// affecting the list of connected interactables
    /// </summary>
     void useButton(ButtonType b)
    {
        print(name + " use");
        switch (b)
        {
            case (ButtonType.TOGGLE):
                toggleActivationForList(interactTargets);
                break;
            case (ButtonType.ACTIVE):
                setActivationForList(interactTargets, true);
                break;
            case (ButtonType.DEACTIVE):
                setActivationForList(interactTargets, false);
                break;

        }
        updateButtonAnimation(interactableActive);


    }

    /// <summary>
    /// called when activating the button
    /// mainly for the player to called this method
    /// </summary>
    public override void activate()
    {
        if (timer_Now < timer+0.5f && timer_Now != 0)
        {
            return;
        }
        try
        {
            StopCoroutine(currentCoroutine);

        } catch(System.Exception _)
        {

        }

        activateBehaviour();
        if (timer > 0f)
        {
            currentCoroutine = StartCoroutine(autoDeactivate());
        }
        PlaySound_use();
    }

    void activateBehaviour()
    {
        switch (buttonType)
        {
            case (ButtonType.TOGGLE):
                interactableActive = !interactableActive;
                useButton(buttonType);
                break;
            case (ButtonType.ACTIVE):
                interactableActive = true;
                useButton(buttonType);
                break;
            case (ButtonType.DEACTIVE):
                base.deactivate();
                useButton(buttonType);
                break;

        }
        
    }

    void reverseBehaviour()
    {
        switch (buttonType)
        {
            case (ButtonType.TOGGLE):
                interactableActive = !interactableActive;
                useButton(ButtonType.TOGGLE);

                break;
            case (ButtonType.ACTIVE):
                interactableActive = true;
                useButton(ButtonType.DEACTIVE);

                break;
            case (ButtonType.DEACTIVE):
                base.deactivate();
                useButton(ButtonType.ACTIVE);

                break;

        }
    }

    //Other
    bool getPlayerInteraction(GameObject other)
    {
        playerInteractionScript = other.GetComponent<PlayerInteractionScript>();
        return playerInteractionScript != null;
    }

    void updateButtonAnimation(bool t)
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

    /// <summary>
    /// set the material of the button's Frenel value
    /// </summary>
    /// <param name="b"></param>
    public void setMaterialFrenel(int b)
    {
        meshRenderer.material.SetFloat("_ActiveFrenel", b);
        print(meshRenderer.material.GetFloat("_ActiveFrenel"));
    }

    //Timer
    IEnumerator autoDeactivate()
    {
        timer_Now = 0;
        yield return new WaitForSeconds(timer);
        reverseBehaviour();
    }
}
