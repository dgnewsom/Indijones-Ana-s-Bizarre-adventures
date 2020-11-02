using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This together with AnimationController.cs controlls menu behavior
// This script handles events that triggered immediately after UI interaction
public class MainMenuController : MonoBehaviour {
    
    public GameObject mainCamera, mainMenu, transition;
    public bool enteringTutorial = true;
    public void GameStartOnClick() {
        mainMenu.SetActive(false);
        mainCamera.GetComponent<Animator>().Play("EnteringGame");
        transition.GetComponent<Animator>().Play("SceneTransitionOut");
    }

    public void GameStartMainOnClick() {
        enteringTutorial = false;
        GameStartOnClick();
    }

    public void GameSettingsOnClick() {
        mainMenu.SetActive(false);
        mainCamera.GetComponent<Animator>().Play("LookAtSettings");
    }

    public void GameExitOnClick() {
        Debug.Log("Quitted");
        Application.Quit();
    }
}
