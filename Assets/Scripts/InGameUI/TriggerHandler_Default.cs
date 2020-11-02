using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler_Default : MonoBehaviour
{
    public GameObject player;
    public GameObject nextTutorial;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMasterHandlerScript>().gameObject;
    }


    void OnTriggerEnter(Collider other) {
        print(other.gameObject == player);
        if (other.gameObject == player) {
            this.gameObject.SetActive(false);
            nextTutorial.SetActive(true);
        }
    }
}
