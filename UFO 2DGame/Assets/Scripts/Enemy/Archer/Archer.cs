using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Archer : Enemy
{
    [SerializeField]
    private float moveSpeed = 5;

    private Rigidbody2D rb2d;
    private Vector2 movement;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //Shoot once every frame because fuck yeah!!
        Shoot();
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void Shoot()
    {
        //Debug.Log("I shooted!");
    }
}
