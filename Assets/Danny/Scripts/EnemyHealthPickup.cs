using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPickup: MonoBehaviour
{
    public int healAmount = 10;
    private Vector3 rotationAngle;
    private float rotationSpeed = 20f;
    private float floatSpeed = 0.003f;
    private bool goingUp = true;
    private float floatRate = 0.3f;
    private float floatTimer;
    [SerializeField]
    private SoundManager soundManager;

    private void Start()
    {
        rotationAngle = new Vector3(0, 1, 0);
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);

        floatTimer += Time.deltaTime;
        Vector3 moveDir = new Vector3(0.0f, floatSpeed, 0.0f);
        transform.Translate(moveDir);

        if (goingUp && floatTimer >= floatRate)
        {
            goingUp = false;
            floatTimer = 0;
            floatSpeed = -floatSpeed;
        }

        else if (!goingUp && floatTimer >= floatRate)
        {
            goingUp = true;
            floatTimer = 0;
            floatSpeed = +floatSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            soundManager.Play("PickupSound");
            other.GetComponent<PlayerLifeSystemScript>().healHealth(healAmount);
            Destroy(gameObject);
            
        }
    }
}
