using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Anson's Test file
/// </summary>
public class AnsonTestManagerScript : MonoBehaviour
{
    Mouse mouse;
    Keyboard keyboard;
    bool useFlag = false;


    private void Start()
    {
        mouse = InputSystem.GetDevice<Mouse>();
        keyboard = InputSystem.GetDevice<Keyboard>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        if (mouse == null)
        {
            mouse = InputSystem.GetDevice<Mouse>();

        }
        if (mouse.leftButton.isPressed)
        {
            testPlayerAttack();
        }
        if (mouse.rightButton.isPressed)
        {
            testHealingPlayer();
        }
        if (keyboard.eKey.isPressed)
        {
            testUse();
            useFlag = false;
        } else if (!keyboard.eKey.isPressed && !useFlag)
        {
            useFlag = true;
        }
        //testOnCollisionDamage();
    }

    void testDamagingPlayer()
    {
        FindObjectOfType<PlayerLifeSystemScript>().takeDamage(Random.Range(5, 10));

    }

    void testHealingPlayer()
    {
        FindObjectOfType<PlayerLifeSystemScript>().healHealth(10);
    }
    void testPlayerAttack()
    {
    }

    void testOnCollisionDamage()
    {
        FindObjectOfType<OnCollisionDamageScript>().transform.position += new Vector3(1, 0, 0) * Mathf.Sin(Time.time);
    }

    void testUse()
    {
        if (useFlag)
        {
            FindObjectOfType<PlayerInteractionScript>().useInteractable();
        }
    }
}
