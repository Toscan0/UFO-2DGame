using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFORotating : MonoBehaviour
{
    private float rotation = 25;

    // Update is called once per frame
    void Update()
    {
        //rotate the UFO
        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);
    }
}
