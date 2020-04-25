using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private Vector2 startingVelocity;

    private Rigidbody2D rb2d;

    public static Action OnEnemyKilled;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = startingVelocity;

        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.Die();
            OnEnemyKilled?.Invoke();
        }

        Destroy(gameObject);
    }
}
