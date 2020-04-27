using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSourceController))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem muzleParticle;
    [SerializeField]
    private AudioClip shotClip;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float attackRate = 1.5f;

    private float attackTimer;

    private AggroDetection aggroDetection;
    private Health healthTarget;
    private AudioSourceController audioSourceController;
    

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetected;
        audioSourceController = GetComponent<AudioSourceController>();
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

        // Animation && Sound
        muzleParticle.Play();
        audioSourceController.Play(shotClip);
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRate;
    }
}
