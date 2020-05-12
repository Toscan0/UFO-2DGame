using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float countdown = 2f;

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Debug.Log("Explode");
            Destroy(gameObject);
        }
    }
}
