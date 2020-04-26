using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fish : MonoBehaviour
{
    [SerializeField]
    private GameObject bubbles;

    [SerializeField]
    private float jumpForce = 100;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * jumpForce);

            StartCoroutine(EnableBubbles());
        }

        if(transform.position.y > 6 || transform.position.y < -5)
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator EnableBubbles()
    {
        bubbles.SetActive(true);
        yield return new WaitForSeconds(3f);
        bubbles.SetActive(false);
    }
}
