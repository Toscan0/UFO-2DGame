using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTarget : MonoBehaviour
{
    private int trigNum = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (trigNum == 0)
            {
                this.gameObject.transform.position = new Vector3(91.73f, 0.7f, 187);
                trigNum = 1;
            }
            if (trigNum == 1)
            {
                this.gameObject.transform.position = new Vector3(152f, 0.7f, 188);
                trigNum = 2;
            }
            if (trigNum == 2)
            {
                this.gameObject.transform.position = new Vector3(152f, 0.7f, 188);
                trigNum = 3;
            }
            if (trigNum == 3)
            {
                this.gameObject.transform.position = new Vector3(152f, 0.7f, 108);
                trigNum = 4;
            }
            if (trigNum == 4)
            {
                this.gameObject.transform.position = new Vector3(91.73f, 0.7f, 108); ;
                trigNum = 0;
            }
        }
    }
}
