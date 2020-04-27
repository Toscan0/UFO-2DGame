using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstracClass
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnShooting?.Invoke();
        }
    }
}
