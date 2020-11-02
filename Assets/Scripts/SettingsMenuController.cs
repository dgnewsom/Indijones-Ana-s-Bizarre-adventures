using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// This together with AnimationController.cs controlls menu behavior
// This script handles events that triggered immediately after UI interaction
public class SettingsMenuController : MonoBehaviour
{
    public GameObject mainCamera, settingsMenu;
    public AudioMixer mixer;
    public void SettingsBackOnClick() {
        settingsMenu.SetActive(false);
        mainCamera.GetComponent<Animator>().Play("LookBackToGame");
    }

    public void SetVolume(float volume) {
        mixer.SetFloat("VolumeLevel", volume);
        Debug.Log(volume);
    }
}
