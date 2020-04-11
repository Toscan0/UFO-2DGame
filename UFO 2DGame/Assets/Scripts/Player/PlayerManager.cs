using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthBar healthBar;

    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private float moveSpeed = 2;

    private static int totalGold = 0;
    private static float currentHealth;

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

    #endregion

    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
