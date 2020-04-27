using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstracClass
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnShooting?.Invoke();
        }
    }
}
