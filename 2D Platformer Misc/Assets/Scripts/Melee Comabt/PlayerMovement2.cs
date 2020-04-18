using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 40f;

    private float horizontalMove = 0f;
    private Vector2 movement;

    private Rigidbody2D rb2d;
    private Animator animator;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = 0;

        animator.SetFloat("Speed", Mathf.Abs(movement.x));
    }

    void FixedUpdate()
    {
         rb2d.MovePosition(rb2d.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
    }
}
