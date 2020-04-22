using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpuleRotation : MonoBehaviour
{
    [SerializeField]
    private float angle = 0;
    

    private void Update()
    {
        Rotate(angle);
    }
    

    private void Rotate(float r)
    {
        // This is not actually a rotation
        // We are setting the transfrom.rotation of the object to a certain value
        // In this case we are setting the Z value
        Vector3 temp = transform.rotation.eulerAngles;
        temp.z = r;
        transform.rotation = Quaternion.Euler(temp);
    }
}
