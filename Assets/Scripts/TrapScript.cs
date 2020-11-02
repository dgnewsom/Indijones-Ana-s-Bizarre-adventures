using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// super class for handling all traps
/// </summary>
public abstract class TrapScript : MonoBehaviour
{
    public bool trapActive = true;
    public GameObject trapObject;



    public virtual void activeTrap()
    {
        trapActive = true;
    }

    public virtual void deactiveTrap()
    {
        trapActive = false;
    }
}
