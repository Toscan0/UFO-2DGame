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
    private int totalGold = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetTotalGold();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
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
