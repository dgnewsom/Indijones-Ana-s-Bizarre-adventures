using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public DamageScript damageScript;
    public WeaponAttackAnimateScript weaponAttackAnimate;

    [Header("Debug Componenets")]
    [SerializeField] Transform box;
    public Camera camera;
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        if (damageScript != null)
        {
            damageScript = GetComponent<BoxCastDamageScript>();
        }
        box = (damageScript as BoxCastDamageScript).box;
        camera = FindObjectOfType<Camera>();
        offset = box.position - transform.position;
        offset = Quaternion.AngleAxis(-transform.eulerAngles.y, Vector3.up) * offset;
    }

    private void Update()
    {
        RotateBox();
    }

    public bool Attack()
    {
        if (damageScript.canDamage())
        {
            damageScript.dealDamage();
            if (weaponAttackAnimate != null)
            {
                weaponAttackAnimate.swingWeapon();
            }
            return true;
        }
        return false;
    }

    void RotateBox()
    {
        Vector3 moveAmount = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * offset;
        box.position = transform.position + moveAmount;
        box.transform.eulerAngles = new Vector3(box.transform.eulerAngles.x, camera.transform.eulerAngles.y, box.transform.eulerAngles.z);
    }
}
