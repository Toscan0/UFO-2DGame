using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Text totalGoldText;

    [SerializeField]
    private float speed = 2;

    private Rigidbody2D rb2d;
    private static int totalGold = 0;

    Vector2 movement;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        SetTotalGold();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

       
    }

    // Especiallized to physics
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            totalGold++;

            SetTotalGold();
        }
    }

    private void SetTotalGold()
    {
        totalGoldText.text = "Gold: " + totalGold.ToString();
    }
}
