using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    protected static float moveSpeed = 2;

    protected static int totalGold = 0;

    protected static int maxHealth = 100;
    protected static int currentHealth;

    protected static int maxXP = 500;
    protected static int currentXP = 0;


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

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public int MaxXP
    {
        get { return maxXP; }
        set { maxXP = value; }
    }

    public int CurrentXP
    {
        get { return currentXP; }
        set { currentXP = value; }
    }

    #endregion
}
