using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extends Damage Script
/// Deals damage on collisionm or on trigger
/// requires collider
/// </summary>
public class OnCollisionDamageScript : DamageScript
{
    [Header("Collision Behaviour")]
    public bool onTrigger;
    

    public bool onEnter = true;
    //public bool onStay;
    //public bool onExit;
    //public bool addToTargetsOnEnter = true;
    //public bool removeFromTargetsOnExit = true;


    private void OnTriggerEnter(Collider other)
    {
        if (onTrigger && onEnter && tagList.Contains(other.gameObject.tag) && other.gameObject.GetComponentInParent<LifeSystemScript>() != null)
        {
            damage(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!onTrigger&& onEnter && tagList.Contains(collision.gameObject.tag) && collision.gameObject.GetComponentInParent<LifeSystemScript>() != null)
        {
            damage(collision.gameObject);
        }
    }

    void damage(GameObject g)
    {
        addAttackedTargets(g);
        dealDamage();
        applyLaunch(g);
    }





}
