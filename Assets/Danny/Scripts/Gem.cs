using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private GemColour colour;
    private GameManager gameManager;
    private Vector3 rotationAngle;
    private float rotationSpeed = 20f;
    private float floatSpeed = 0.003f;
    private bool goingUp = true;
    private float floatRate = 0.3f;
    private float floatTimer;
    private SoundManager soundManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        soundManager = FindObjectOfType<SoundManager>();
        rotationAngle = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);

        floatTimer += Time.deltaTime;
            Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
            transform.Translate(moveDir);

            if (goingUp && floatTimer >= floatRate)
            {
                goingUp = false;
                floatTimer = 0;
                floatSpeed = -floatSpeed;
            }

            else if(!goingUp && floatTimer >= floatRate)
            {
                goingUp = true;
                floatTimer = 0;
                floatSpeed = +floatSpeed;
            }
    }


    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player")){
            soundManager.Play("PickupSound");
            gameManager.CollectGem(colour);
            Destroy(gameObject);
        }
    }

}
