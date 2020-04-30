using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTarget : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            this.gameObject.transform.position = new Vector3(91.73f, 0.7f, 150);
        }
    }
}
