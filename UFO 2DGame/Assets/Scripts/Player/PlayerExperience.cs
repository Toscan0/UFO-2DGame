using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerExperience : PlayerManager
{
    public ExperienceBar experienceBar;

    private void Start()
    {
        experienceBar.SetMaxExperience(maxXP);

        experienceBar.SetExperience(currentXP);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            IncreaseXP(20);
        }
    }

    public void IncreaseXP(int xp)
    {
        currentXP += xp;

        experienceBar.SetExperience(currentXP);
    }
}
