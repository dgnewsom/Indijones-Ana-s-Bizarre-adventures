using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This together with MenuControllers controlls menu behavior
// This script handles events triggered after animations
public class AnimationController : MonoBehaviour
{
    public GameObject settingsMenu, mainMenu;
    public void EnteringGameFinished() {
        if (mainMenu.GetComponent<MainMenuController>().enteringTutorial) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void LookingAtSettings() {
        settingsMenu.SetActive(true);
    }

    public void LookingBackToGame() {
        mainMenu.SetActive(true);
    }
}
