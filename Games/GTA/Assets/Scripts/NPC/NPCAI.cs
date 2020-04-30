using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCAI : MonoBehaviour
{
    public GameObject desinationPoint;

    NavMeshAgent theAgent;

    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }



    void Update()
    {
        theAgent.SetDestination(desinationPoint.transform.position);
    }
}
