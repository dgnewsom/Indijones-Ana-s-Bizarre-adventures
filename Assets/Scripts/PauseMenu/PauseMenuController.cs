using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu, pauseMenuMain, pauseMenuSettings;
    public AudioMixer mixer;
    bool m_paused = false;

    void Update() {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (keyboard.escapeKey.wasReleasedThisFrame) {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu() {
        if (m_paused) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
            pauseMenu.SetActive(false);
        } else {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0.0f;
            AudioListener.pause = true;
            pauseMenu.SetActive(true);
        }
        m_paused = !m_paused;
    }
    public void SettingsBackOnClick() {
        pauseMenuSettings.SetActive(false);
        pauseMenuMain.SetActive(true);
    }

    public void SetVolume(float volume) {
        mixer.SetFloat("VolumeLevel", volume);
        Debug.Log(volume);
    }
    public void ResumeOnClick() {
        TogglePauseMenu();
    }

    public void SettingsOnClick() {
        pauseMenuMain.SetActive(false);
        pauseMenuSettings.SetActive(true);
    }

    public void ExitToMainOnClick() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartMenu");
    }
}
