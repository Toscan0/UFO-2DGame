using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;

        SetHealth(maxHealth);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
