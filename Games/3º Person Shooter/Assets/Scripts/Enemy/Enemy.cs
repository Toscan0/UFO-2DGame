using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float attackRefreshRate = 1.5f;

    private float attackTimer;

    private AggroDetection aggroDetection;
    private Health healthTarget;

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetected;
    }

    private void AggroDetected(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if(health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {
        if(healthTarget != null)
        {
            attackTimer += Time.deltaTime;

            if (CanAttack())
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(damage);
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }
}
