using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(float health) {
        slider.value = health;
    }
}
