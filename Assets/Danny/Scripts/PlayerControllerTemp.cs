using UnityEngine;
using System.Collections;

public class PlayerControllerTemp : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
/*
    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Damage");
            other.GetComponent<LifeSystemScript>().takeDamage(10);
        }
    }
    */
}