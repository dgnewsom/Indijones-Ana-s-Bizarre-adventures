using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _Debug_ReturnToMain : MonoBehaviour
{
    public void ReturnOnClick() {
        SceneManager.LoadScene("StartMenu");
    }
}
