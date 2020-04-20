using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void Teleport(Vector3 pos);
    public static event Teleport OnTeleport;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(OnTeleport != null)
            {
                OnTeleport(new Vector3(0, 2, 0));
            }
        }
    }
}
