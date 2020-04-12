using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerExperience : MonoBehaviour
{
    public ExperienceBar experienceBar;

    private float maxXP;
    private float currentXP;
    
    private void Start()
    {
        maxXP = GetComponent<PlayerManager>().MaxExperience;
        experienceBar.SetMaxExperience(maxXP);

        currentXP = GetComponent<PlayerManager>().CurrentExperience;
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
