using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class ExperienceBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxExperience(float maxXP)
    {
        slider.maxValue = maxXP;
    }

    public void SetExperience(float xp)
    {
        slider.value = xp;

        /*
         * TODO: If max experience -> update experience lvl
         */ 
    }
}
