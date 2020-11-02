using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundScript : MonoBehaviour
{
    public SoundManager soundManager;
    [Header("Sounds")]
    public Sound Sound_takeDamage;
    public Sound Sound_attack;
    public Sound Sound_walking;
    public Sound Sound_jump;
    public Sound Sound_death;

    [Header("Walking")]
    private bool isWalkig = false;
    public float timeBetweenWalkingSound = 1f;
    private float timeNow_walking = 0;

    private void FixedUpdate()
    {
        if (isWalkig&&timeNow_walking<= 0)
        {
            timeNow_walking = timeBetweenWalkingSound;
            soundManager.Play(Sound_walking);
        }
        else if (timeNow_walking > 0)
        {
            timeNow_walking -= Time.deltaTime;
        }
    }


    public void playSound_takeDamage()
    {
        soundManager.Play(Sound_takeDamage);
    }

    public void playSound_attack()
    {
        soundManager.Play(Sound_attack);
    }
    public void playSound_walking(bool b = true)
    {
        isWalkig = b;
    }
    public void playSound_jump()
    {
        soundManager.Play(Sound_jump);
    }
    public void playSound_death()
    {
        soundManager.Play(Sound_death);
    }
}
