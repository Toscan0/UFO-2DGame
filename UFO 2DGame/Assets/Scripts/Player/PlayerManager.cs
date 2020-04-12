using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    protected static float moveSpeed = 2;

    protected static int totalGold = 0;

    protected static float maxHealth = 100;
    protected static float currentHealth;

    protected static float maxXP = 500;
    protected static float currentXP = 0;


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

    public float MaxXP
    {
        get { return maxXP; }
        set { maxXP = value; }
    }

    public float CurrentXP
    {
        get { return currentXP; }
        set { currentXP = value; }
    }

    #endregion
}
