using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extends Trap Script
/// swings the trap from left to right according to the max angle
/// swing speed follows a sin wave
/// </summary>
public class SwingTrapScript : TrapScript
{
    public float swingSpeed = 10f;
    public float swingMaxAngle = 90f;
    public float offSetAngle = 0;
    public float offSetStartAngle = 0;
    public float deactiveAngle = 0;


    private Quaternion initialRot;
    float swingAngle = 0f;



    private void Awake()
    {
        initialRot = trapObject.transform.localRotation;
    }

    private void Update()
    {
        if (trapActive)
        {
            rotateSwingObject();
        }
        else
        {
            toOriginal();
        }
    }

    void rotateSwingObject()
    {
        swingAngle = Mathf.Sin(Time.time * swingSpeed + asinAngle(offSetStartAngle)) * (swingMaxAngle / 2f);
        swingAngle += offSetAngle;
        trapObject.transform.rotation = Quaternion.Lerp(trapObject.transform.rotation, Quaternion.AngleAxis(swingAngle, transform.right) * initialRot * transform.rotation, swingSpeed*10 * Time.deltaTime);
    }

    float asinAngle(float angle)
    {
        float r = angle / (swingMaxAngle / 2f);
        //r -= Mathf.Floor(r);
        r = Mathf.Asin(r);
        return r;
    }

    void toOriginal()
    {
        trapObject.transform.rotation = Quaternion.Lerp(trapObject.transform.rotation, Quaternion.AngleAxis(deactiveAngle, transform.right) * initialRot * transform.rotation, 1 * Time.deltaTime);

    }

    public override void deactiveTrap()
    {
        base.deactiveTrap();
    }
}
