using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Main Player Handler, only get this component from outside of player
/// </summary>
public class PlayerMasterHandlerScript : MonoBehaviour
{
    [Header("Player Components")]
    public PlayerLifeSystemScript playerLifeSystem;
    public PlayerController playerController;
    public PlayerInteractionScript playerInteraction;
    [Header("Attack")]
    public PlayerAttackScript playerAttack;
    [Header("Interact")]
    public PlayerInteractionScript playerInteractionScript;
    [Header("Sound")]
    public SoundManager soundManager;
    public PlayerSoundScript playerSoundScript;
    [Header("Outside Components")]
    public HealthBarController healthBarController;
    public EndingEventHandler endingEventHandler;


    private void Awake()
    {
        if (healthBarController == null)
        {
            healthBarController = FindObjectOfType<HealthBarController>();

        }
        playerLifeSystem.healthBarController = healthBarController;
        soundManager = FindObjectOfType<SoundManager>();
        playerSoundScript = GetComponent<PlayerSoundScript>();
        playerSoundScript.soundManager = soundManager;
        endingEventHandler = FindObjectOfType<EndingEventHandler>();
    }
    /// <summary>
    /// Attacking the player and playing the animation
    /// </summary>
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (playerAttack.Attack())
            {
                playerSoundScript.playSound_attack();
                //playerController.RotateWithCamera_Force();
            }
        }
    }
    /// <summary>
    /// Called by player input to move the character
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        if (!playerLifeSystem.IsDead)
        {
            if (context.performed)
            {
                playerController.Move(context);
                playerSoundScript.playSound_walking();

            }

        }
        if (context.ReadValue<Vector2>().magnitude < 0.1f || !playerController.Grounded)
        {
            playerSoundScript.playSound_walking(false);
        }
    }
    /// <summary>
    /// Called by player input have the character jump
    /// </summary>
    /// <param name="context"></param>
    public void Jump(InputAction.CallbackContext context)
    {
        if (!playerLifeSystem.IsDead)
        {
            if (context.performed)
            {
                if (playerController.Grounded)
                {

                    playerSoundScript.playSound_jump();
                }
                if (playerController.Jump(context))
                {
                }
            }
        }
    }

    /// <summary>
    /// get the fraction of the player's health
    /// </summary>
    /// <returns> fraction of the player's health </returns>
    public float getHealthFraction()
    {
        if (playerLifeSystem != null)
        {
            return (float)playerLifeSystem.Health_Current / (float)playerLifeSystem.Health_Max;
        }
        return 0f;

    }

    public void UseInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Interact pressed");
            playerInteractionScript.useInteractable();
        }
        else if (context.canceled)
        {
            playerInteraction.ResetFlag();
        }
    }

    public void GameOver(float v = 1f)
    {
        if (endingEventHandler != null)
        {
            endingEventHandler.TriggerOnDeathDelay(v);
        }
    }
}
