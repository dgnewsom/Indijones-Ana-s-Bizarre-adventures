using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used to create some dynamic effects for main menu
public class LightShift : MonoBehaviour
{
    public float maxIntensity, minIntensity;
    void Start() {
        StartCoroutine(changeIntensity());
    }

    IEnumerator changeIntensity() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Light>().intensity = Random.Range(minIntensity, maxIntensity);
        StartCoroutine(changeIntensity());
    }
}
