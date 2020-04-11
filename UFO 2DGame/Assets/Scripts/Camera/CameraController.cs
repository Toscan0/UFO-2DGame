using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        offsetY = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y + offsetY, 0);
    }
}
