using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extends Life System Script
/// for player
/// </summary>
public class PlayerLifeSystemScript : LifeSystemScript
{
    [Header("Components+")]
    private PlayerMasterHandlerScript playerMasterHandlerScript;
    [Header("Player Animator")]
    public Animator animator;
    public string deathTriggerName = "Death";
    [Header("Sound")]
    public PlayerSoundScript playerSoundScript;

    private void Awake()
    {
        base.health_Current = base.Health_Max;
        updateHealthBar();
        playerSoundScript = GetComponent<PlayerSoundScript>();
        playerMasterHandlerScript = GetComponent<PlayerMasterHandlerScript>();

    }

    public override void DeathBehaviour()
    {
        base.DeathBehaviour();
    }

    public override int takeDamage(float dmg)
    {
        int i = base.takeDamage(dmg);
        if (i > 0)
        {
            playerSoundScript.playSound_takeDamage();
        }
        return Health_Current;
    }

    /// <summary>
    /// applies a delay so that that the animatorcan play the death animation, before disabling the player GameObject
    /// </summary>
    /// <returns></returns>
    public override IEnumerator delayDeathRoutine()
    {
        playerSoundScript.playSound_death();
        animator.SetBool(deathTriggerName, IsDead);
        playerMasterHandlerScript.GameOver(delayDeath+1);
        yield return new WaitForSeconds(delayDeath);
        DeathBehaviour();
    }




}
