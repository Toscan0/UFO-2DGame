using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private NavMeshAgent navMesMeshAgent;
    private Animator animator;
    private Transform target;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetected;

        navMesMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void AggroDetected(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if(target != null)
        {
            navMesMeshAgent.SetDestination(target.position);
            animator.SetFloat("Speed", navMesMeshAgent.velocity.magnitude);
        }
    }
}
