using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEndingController : MonoBehaviour
{
    GameObject player;
    GameManager gameManager;
    public GameObject endingType;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMasterHandlerScript>().gameObject;
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            if (gameManager.allGemsCollected()) {
                endingType.GetComponentInChildren<TMP_Text>().text = "Coins Collected: " + gameManager.coinsCollected;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                endingType.SetActive(true);
            }
        }
    }
}
