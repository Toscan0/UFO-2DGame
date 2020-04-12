using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Archer : Enemy
{
    public Transform firePoint;
    public GameObject arrowPrefab;



    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Shoot
    private float shootTimer;
    [SerializeField]
    private int shootWaitingTime = 3;

    //Movement
    [SerializeField]
    private float moveSpeed = 5;
    private float moveTimer;
    [SerializeField]
    private int moveWaitingTime = 5;
    private Vector2 movement;
    private bool move = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootWaitingTime)
        {
            Shoot();
            shootTimer = 0;
        }

        moveTimer += Time.deltaTime;
        if (moveTimer > moveWaitingTime)
        {
            Move();
            move = false;
        }
        if(moveTimer > moveWaitingTime + 1)
        {
            movement.x = 0;
            movement.y = 0;

            moveTimer = 0;
            move = true;
        }

        //since there are no lefts walk sprites
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }

    private void Move()
    {
        if(move == true)
        {
            movement.x = Random.Range(-1f, 1f);
            movement.y = Random.Range(-1f, 1f);
            Debug.Log(movement.x + " " + movement.y);
        }
    }
}
