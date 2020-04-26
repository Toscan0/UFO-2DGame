using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField]
    private Text XPtext;

    private float XP = 0;
    private static float MaxXP = 0;

    private void Start()
    {
        Fireball.OnEnemyKilled += UpdateExperience;

        SetText();
    }

    private void UpdateExperience()
    {
        XP++;

        if(XP > MaxXP)
        {
            MaxXP = XP;
        }

        SetText();
    }

    private void SetText()
    {
        XPtext.text = "XP: " + XP + "\nMax XP: " + MaxXP;
    }

    private void OnDisable()
    {
        Fireball.OnEnemyKilled -= UpdateExperience;
    }
}
