using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerManager))]
public class PlayerMovement: PlayerManager
{
    private Rigidbody2D rb2d;
    private Vector2 movement;
    //private float moveSpeed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //moveSpeed = GetComponent<PlayerManager>().MoveSpeed;
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    // Especiallized to physics
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
