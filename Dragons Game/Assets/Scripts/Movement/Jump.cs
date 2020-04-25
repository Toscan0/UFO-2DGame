using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private Vector2 jumpForce;
    [SerializeField]
    private AudioClip jumpClip;

    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = jumpClip;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb2d.AddForce(jumpForce);

            audioSource.Play();
        }
    }
}
