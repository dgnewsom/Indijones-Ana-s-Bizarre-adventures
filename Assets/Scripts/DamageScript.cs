using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// super class for handling dealing damage to life system
/// </summary>
public class DamageScript : MonoBehaviour
{
    [Header("States")]
    [SerializeField] Vector2 damageRange;
    [SerializeField] float timeBetweenAttack;
    [Header("Target")]
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected List<string> tagList;
    [Header("Launch On Collision")]
    public Transform launchPoint;
    public bool launchOnCollision = true;
    [SerializeField] Vector3 launchDir;
    public float launchForce = 200f;
    [Header("Debug")]
    [SerializeField] protected List<LifeSystemScript> attackedTargets = new List<LifeSystemScript>();
    [SerializeField] float timeBetweenAttack_TimeNow = 0;

    private void Awake()
    {
        if (damageRange.x > damageRange.y)
        {
            float i = damageRange.x;
            damageRange.x = damageRange.y;
            damageRange.y = i;
        }
    }

    private void FixedUpdate()
    {
        if (timeBetweenAttack_TimeNow > 0)
        {
            timeBetweenAttack_TimeNow -= Time.deltaTime;
        }
    }
    /// <summary>
    /// deals damage to a single target that has a LifeSystemScript
    /// </summary>
    /// <param name="ls"></param>
    public virtual void dealDamageToTarget(LifeSystemScript ls)
    {
        ls.takeDamage(Random.Range(damageRange.x, damageRange.y));
    }


    /// <summary>
    /// deals damage to all targets in the list attackedTargets
    /// 
    /// </summary>
    public virtual void dealDamage()
    {
        if (timeBetweenAttack_TimeNow > 0)
        {
            return;
        }
        foreach (LifeSystemScript ls in attackedTargets)
        {
            dealDamageToTarget(ls);
        }
        attackedTargets = new List<LifeSystemScript>();

        timeBetweenAttack_TimeNow = timeBetweenAttack;
    }

    /// <summary>
    /// Add the collided gameobject to a list, so it won't deal damage multiple times
    /// </summary>
    /// <param name="collision"> gameobject that it did damage to </param>
    protected void addAttackedTargets(GameObject collision)
    {
        LifeSystemScript ls;
        ls = collision.GetComponentInParent<LifeSystemScript>();
        if (!attackedTargets.Contains(ls))
        {
            attackedTargets.Add(ls);
        }
    }

    protected void applyLaunch(GameObject collision)
    {
        if (launchOnCollision)
        {
            if (launchPoint == null)
            {
            launchDir = (collision.transform.position - transform.position).normalized;

            }
            else
            {
                launchDir = (collision.transform.position - launchPoint.position).normalized;

            }
            Rigidbody rb = collision.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(launchDir * launchForce * rb.mass);
                //print("launching " + rb.name);
            }

            CharacterController cc = collision.GetComponentInParent<CharacterController>();
            if (cc != null)
            {
                cc.Move(launchDir);
                print("launching " + rb.name);

            }
        }
    }

    public bool canDamage()
    {
        return timeBetweenAttack_TimeNow <= 0;
    }


}
