using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);
         
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
