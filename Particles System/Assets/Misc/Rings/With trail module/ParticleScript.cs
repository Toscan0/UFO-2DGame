using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public Vector3 speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
