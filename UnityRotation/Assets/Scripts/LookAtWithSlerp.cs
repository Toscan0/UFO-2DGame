using UnityEngine;
using System.Collections;

public class LookAtWithSlerp : MonoBehaviour
{
    [SerializeField]
    private Transform target;


    void Update()
    {
        Vector3 relativePos = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        Debug.DrawRay(transform.position, relativePos, Color.green);
    }
}