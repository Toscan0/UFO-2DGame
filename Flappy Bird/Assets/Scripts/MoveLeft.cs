using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float randomOffSet = 1.5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -7)
        {
            if(randomOffSet == 0)
            {
                transform.position = new Vector3(7, transform.position.y, transform.position.z);
            }
            else
            {
                float randomHeight = UnityEngine.Random.Range(-randomOffSet, randomOffSet);
                transform.position = new Vector3(7, randomHeight, transform.position.z);
            }
        }
    }
}
