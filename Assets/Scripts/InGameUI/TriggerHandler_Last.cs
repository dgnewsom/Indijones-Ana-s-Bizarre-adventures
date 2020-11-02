using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler_Last : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMasterHandlerScript>().gameObject;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            this.gameObject.SetActive(false);
        }
    }
}
