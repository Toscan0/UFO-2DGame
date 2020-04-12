using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2;

    private static int totalGold = 0;

    private static float maxHealth = 100;
    private static float currentHealth;
    
    private static float maxExperience = 500;
    private static float currentExperience;

    #region GETS&SETS

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public int TotalGold
    {
        get { return totalGold; }
        set { totalGold = value; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public float MaxExperience
    {
        get { return maxExperience; }
        set { maxExperience = value; }
    }

    public float CurrentExperience
    {
        get { return currentExperience; }
        set { currentExperience = value; }
    }

    #endregion
}
