using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if(player != null)
        {
            Debug.Log("Aggrod");
            OnAggro?.Invoke(player.transform);
        }
    }
}
