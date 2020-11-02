using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extend Trap Script
/// for having a spinning trap
/// spins the object in 360 dgrees at a constant speed
/// </summary>
public class SpinTrapScript : TrapScript
{

    public float spinTime = 1f; //time for object to do a full 360 spin
    Quaternion spinAngle;


    private void Update()
    {
        if (trapActive)
        {
            rotateSwingObject();
        }
    }

    void rotateSwingObject()
    {
        spinAngle = Quaternion.AngleAxis(360 * (1 / spinTime)*Time.deltaTime, transform.up);
        trapObject.transform.rotation = spinAngle* trapObject.transform.rotation;
    }

}
