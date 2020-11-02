using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private GameManager gameManager;
    private Vector3 rotationAngle;
    private float rotationSpeed = 40f;
    private float floatSpeed = 0.003f;
    private bool goingUp = true;
    private float floatRate = 0.3f;
    private float floatTimer;
    private SoundManager soundManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        soundManager = FindObjectOfType<SoundManager>();
        rotationAngle = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);

        floatTimer += Time.deltaTime;
        Vector3 moveDir = new Vector3(floatSpeed, 0.0f, 0.0f);
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
            gameManager.CollectCoin(); ;
            Destroy(gameObject);
        }
    }
}
