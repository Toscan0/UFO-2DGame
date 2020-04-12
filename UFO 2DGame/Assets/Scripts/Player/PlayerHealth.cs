using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    
    private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        maxHealth = GetComponent<PlayerManager>().MaxHealth;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
